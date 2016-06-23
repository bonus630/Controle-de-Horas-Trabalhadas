using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;


namespace br.corp.bonus630.ControleHorasTrabalhadas.ControleHorasTrabalhadas
{
    class DbControl
    {
       
        string conectionString = "Persist Security Info=False;server=" + Properties.Settings.Default.dbserver + ";user=" + Properties.Settings.Default.dbuser + ";database=controle_horas_trabalhadas;port=3306;password=" + Properties.Settings.Default.dbpassword + ";";

        public DbControl()
        {
        }
        private MySqlConnection checkConection()
        {
            MySqlConnection conn =  new MySqlConnection(conectionString);
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                }
                catch(Exception erro)
                {
                    throw erro;
                }
            }
            return conn;
        }
        public bool checkMysql()
        {
            try
            {
                MySqlConnection conn = this.checkConection();
                
                conn.Close();
                return true;
            }
            catch(Exception erro)
            {
                return false;
            }
}
        public List<People> getAllWorkers()
        {
            List<People> funcionarios = new List<People>();
            try
            {
                 MySqlConnection conn = checkConection();
                
                string sql = "select * from funcionarios where funcionario_id > 1 order by funcionario_ativo desc";
                MySqlCommand comand = new MySqlCommand(sql, conn);
                using (MySqlDataReader dataReader = comand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        funcionarios.Add(new People((int)dataReader[0], (string)dataReader[1], (string)dataReader[2], (string)dataReader[3], this.isWork((int)dataReader[0])));
                    }
                }
                conn.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            
            
            return funcionarios;
        }
        public int getLastWorkId()
        {
            int result = -1;
            try
            {
                MySqlConnection conn = checkConection();
                string sql = "select funcionario_id from funcionarios order by funcionario_id desc limit 1";
                MySqlCommand comand = new MySqlCommand(sql, conn);
                MySqlDataReader dataReader = comand.ExecuteReader();
               
                if (dataReader.Read())
                {
                    result = dataReader.GetInt32(0);
                }
                conn.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            
            
            return result;
        }
        public DateTime getFirstDatePeriod(int worker,string status,bool first)
        {
            DateTime result = new DateTime();
            try
            {
                MySqlConnection conn = checkConection();
                string condition = "";
                if (!string.IsNullOrEmpty(status))
                    condition = " and periodo_status='" + status + "'";
                string sql = "";
                if (first)
                    sql = "select periodo_inicio from periodos where funcionario_id=" + worker + condition+" order by periodo_id asc limit 1";
                else
                    sql = "select periodo_fim from periodos where funcionario_id=" + worker + condition+" order by periodo_id desc limit 1";
                MySqlCommand comand = new MySqlCommand(sql, conn);
                MySqlDataReader dataReader = comand.ExecuteReader();
                //int results = dataReader.RecordsAffected;
                if (dataReader.Read())
                {
                    if(!dataReader.IsDBNull(0))
                        result = dataReader.GetDateTime(0);
                    else
                        result = DateTime.Now.Date;
                }
                conn.Close();
                
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return result;
        }
        private List<Period> getPeriods(int worker,string condition)
        {
            List<Period> periods = new List<Period>();
            try 
            {
                MySqlConnection conn = checkConection();
                string sql = "select * from periodos where funcionario_id="+worker+condition;
                MySqlCommand comand = new MySqlCommand(sql, conn);
                MySqlDataReader dataReader = comand.ExecuteReader();
                int results = dataReader.RecordsAffected;
                while(dataReader.Read())
                {
                    Period temp = new Period();
                    temp.Id = (int)dataReader[0];
                    temp.StartDate =(DateTime)dataReader[1];
                    if (!dataReader.IsDBNull(2))
                        temp.EndDate = (DateTime)dataReader[2];
                    else
                        temp.EndDate = DateTime.Now;
                    if (!dataReader.IsDBNull(3))
                        temp.PayDate = (DateTime)dataReader[3];
                    temp.WorkerId = (int)dataReader[4];
                    temp.Status = dataReader.GetChar(5);
                    temp.ValueHour =(double) dataReader.GetDecimal(6);
                    periods.Add(temp);
                }
                conn.Close();
            }
            catch(Exception erro)
            {
                throw erro;
            }
           
            
            return periods;
        }
        public List<Period> getPayPeriods(int worker)
        {
            return this.getPeriods(worker, " and periodo_status='y'");
        }
        public List<Period> getPayPeriodsInInterval(int worker,string startDate,string endDate)
        {
            return this.getPeriods(worker, " and periodo_status='y' and date(periodo_inicio) >= '"+startDate+"' and date(periodo_fim) <= '"+endDate+"'");
        }
        public List<Period> getAllPeriods(int worker)
        {
            return this.getPeriods(worker, "");
        }
        public List<Period> getNotPayPeriods(int worker)
        {
            return this.getPeriods(worker, " and periodo_status='n'");
        }
        public Period getPeriod(int worker,int periodId)
        {
            List<Period> periods = this.getPeriods(worker, " and periodo_id=" + periodId);
            if (periods.Count > 0)
                return periods[0];
            else
                return null;
        }
        /// <summary>
        /// Retorna o id do Período atual
        /// </summary>
        /// <param name="workerId"></param>
        /// <returns></returns>
        public int getPeriodId(int workerId)
        {
            int result = -1;
            try
            {
                MySqlConnection conn = checkConection();

                string sql = "select periodo_id from periodos where funcionario_id=" + workerId + " and periodo_status='n'";
                MySqlCommand comand = new MySqlCommand(sql, conn);
                MySqlDataReader dataReader = comand.ExecuteReader();
                if (dataReader.Read())
                {
                    
                    result = (int)dataReader[0];
                }
                conn.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            
            return result;
        }
        public void createNewPeriod(int workerId,string dateStart)
        {
            int periodId = this.getPeriodId(workerId);
            if (periodId == -1)
            {
                try
                {
                    string sql = "insert into periodos (periodo_inicio,funcionario_id) values('"+dateStart+"'," + workerId + ");";
                    MySqlConnection conn = checkConection();
                    MySqlCommand comand = new MySqlCommand(sql, conn);
                    //MySqlDataReader dataReader = comand.ExecuteReader();
                    int result = comand.ExecuteNonQuery();
                    conn.Close(); 
                }
                catch (Exception erro)
                {
                    throw erro;
                }
               
            }
            
        }
        private DateTime getLastHourFromDate(DateTime date, int workerId)
        {
            DateTime result = new DateTime();
            string sql = "select hora_s from horarios where funcionario_id=1003 and date(hora_s)<='" + date.ToString("yyyy-MM-dd") + "' order by hora_s desc limit 1;";
            MySqlConnection conn = checkConection();
            MySqlCommand comand = new MySqlCommand(sql,conn);
           // comand.Connection = conn;
          //  comand.CommandText = sql;
          //  comand.Prepare();
         //   comand.Parameters.AddWithValue("@dateFinalValue", date);
            MySqlDataReader dataReader = comand.ExecuteReader();
            if(dataReader.Read())
            {
                result = (DateTime) dataReader.GetDateTime(0);
            }
            conn.Close();
            return result;
        }
        public bool setPayPeriod(int periodId,int workerId,DateTime dateEnd,decimal hourValue)
        {
            try
            {
                DateTime finalDate = getLastHourFromDate(dateEnd, workerId);
               
                string dateEndString = dateEnd.Date.ToString("yyyy-MM-dd");
                MySqlConnection conn = checkConection();
               // MySqlParameter parameterHourValue = new MySqlParameter(":hourValue", MySqlDbType.Decimal);
              //  parameterHourValue.Value = hourValue;
              //  MySqlParameterCollection parameters = new MySqlParameterCollection();
              //  parameters.Add(parameterHourValue);
                string sql = "update periodos set periodo_status='y',periodo_fim='"+finalDate.ToString("yyyy-MM-dd HH:mm:ss")+"',periodo_data_pagamento=now(),periodo_valor_hora=@hourValue where periodo_id="+periodId+";";
                
                MySqlCommand comand = new MySqlCommand();
                comand.Connection = conn;
                comand.CommandText = sql;
                comand.Prepare();
                comand.Parameters.AddWithValue("@hourValue", hourValue);
                
                int result = comand.ExecuteNonQuery();
                if (result == 1)
                {
                    dateEndString = finalDate.AddSeconds(1).ToString("yyyy-MM-dd HH:mm:ss");
                    this.createNewPeriod(workerId,dateEndString);
                    conn.Close();
                    return true;
                }

            }
            catch (Exception erro)
            {
                throw erro;
            }
            
            
            return false;

        }
        public bool insertWorker(People worker)
        {
            try
            {
                MySqlConnection conn = checkConection();
                string sql = "insert into funcionarios (funcionario_nome,funcionario_foto,funcionario_ativo)values('" + worker.Name + "','" + worker.PhotoName + "','y');";
                MySqlCommand comand = new MySqlCommand(sql, conn);
                int result = comand.ExecuteNonQuery();
                if (result == 1)
                {
                    conn.Close();
                    return true;
                }

            }
            catch (Exception erro)
            {
                throw erro;
            }
            
          
            return false;
        }
        public bool isAdmin(int id)
        {
            if (id == 1000)
                return true;
            else
                return false;
        }
        public People getWorker(int workerId)
        {
            try
            {
                MySqlConnection conn = checkConection();
                string sql = "select * from funcionarios where funcionario_id = "+workerId+";";
                MySqlCommand comand = new MySqlCommand(sql, conn);
                MySqlDataReader dataReader = comand.ExecuteReader();
                if (dataReader.Read())
                {
                    People temp = new People((int)dataReader[0], (string)dataReader[1], (string)dataReader[2], (string)dataReader[3], this.isWork((int)dataReader[0]));
                    conn.Close();
                    return temp;
                }
            }
            catch (Exception erro)
            {
                throw erro;
            }
           
            
            return null;
        }
        /// <summary>
        /// Recupera uma lista de registros dos horários não finalizados
        /// </summary>
        /// <param name="workerId">Id do funcionário</param>
        /// <returns>Lista de horários não finalizados</returns>
        public List<Hours> inWork(int workerId)
        {
            List<Hours> listHours = new List<Hours>();
            try
            {
                MySqlConnection conn = checkConection();
                string sql = "select hora_id, hora_e,funcionario_id from horarios where funcionario_id = " + workerId + " and hora_s is null;";
                MySqlCommand comand = new MySqlCommand(sql, conn);
                MySqlDataReader dataReader = comand.ExecuteReader();
                while (dataReader.Read())
                {
                    Hours h = new Hours();
                    h.Start = (DateTime)dataReader[1];
                    h.WorkerId = (int)dataReader[2];
                    h.Id = (int)dataReader[0];
                    listHours.Add(h);
                    
                }
                conn.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
          
                
            
            return listHours;
        }
        /// <summary>
        /// Recupera uma lista de registros dos horários  finalizados
        /// </summary>
        /// <param name="workerId">Id do funcionário</param>
        /// <returns>Lista de horários finalizados</returns>
        public List<Hours> inWorked(int workerId, string dateTimeStart, string dateTimeEnd)
        {
            List<Hours> listHours = new List<Hours>();
            try
            {
                MySqlConnection conn = checkConection();
                string sql = "select hora_id, hora_e,hora_s from horarios where funcionario_id = " + workerId + " and hora_s is not null and date(hora_e)>='" + dateTimeStart + "'";
                if (!string.IsNullOrEmpty(dateTimeEnd))
                    sql += " and date(hora_s) <= '" + dateTimeEnd + "';";
                MySqlCommand comand = new MySqlCommand(sql, conn);
                MySqlDataReader dataReader = comand.ExecuteReader();
                while (dataReader.Read())
                {
                    Hours h = new Hours();
                    h.Start = (DateTime)dataReader[1];
                    h.End = (DateTime)dataReader[2];
                    h.WorkerId = workerId;
                    h.Id = (int)dataReader[0];
                    listHours.Add(h);

                }
                conn.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
           
                
            
            return listHours;
        }
        /// <summary>
        /// Verifica se o funcionários está trabalhando neste dia
        /// </summary>
        /// <param name="workerId">id do funcionário</param>
        /// <returns>true se estiver trabalhando e false se nã</returns>
        public bool isWork(int workerId)
        {
            bool result = false;
            try
            {
                MySqlConnection conn = checkConection();
                string sql = 
"select hora_e from horarios where  hora_s is null and funcionario_id="+workerId+" and date(hora_e)=date(now());";
                MySqlCommand comand = new MySqlCommand(sql, conn);
                MySqlDataReader dataReader = comand.ExecuteReader();
               
                if (dataReader.Read())
                {
                    result = true;
                   

                }
               conn.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            
                
            
             return result;
        }
        public bool editWorker(People worker)
        {
            bool result = false;
            try
            {
                MySqlConnection conn = checkConection();
                string ative = "n";
                if(worker.Active)
                    ative = "y";
                string sql = "update funcionarios set funcionario_nome='"+worker.Name+"',funcionario_foto='"+worker.PhotoName+"',funcionario_ativo='"+ative+"' where funcionario_id="+worker.Id+";";
                MySqlCommand comand = new MySqlCommand(sql, conn);
              
                if (comand.ExecuteNonQuery() == 1)
                    result = true;
                conn.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
           
                
            
            return result;
        }
        /// <summary>
        /// Retorna a soma total das horas de um funcionário
        /// </summary>
        /// <param name="workerId"></param>
        /// <param name="dateTimeStart"></param>
        /// <param name="dateTimeEnd"></param>
        /// <returns></returns>
        public TimeSpan getSumHours(int workerId,string dateTimeStart,string dateTimeEnd)
        {
            TimeSpan result = new TimeSpan();
            try
            {
                MySqlConnection conn = checkConection();
                string sql =
                    "select sec_to_time(sum(TIME_TO_SEC(hora_s) - time_to_sec(hora_e))) as Total from horarios where funcionario_id= " + workerId + " and date(hora_e)>='" + dateTimeStart + "'";
                if(!string.IsNullOrEmpty(dateTimeEnd))
                    sql+= " and date(hora_s) <= '" + dateTimeEnd + "';";
                MySqlCommand comand = new MySqlCommand(sql, conn);
                MySqlDataReader dataReader = comand.ExecuteReader();

                if (dataReader.Read()&& !dataReader.IsDBNull(0))
                {
                    result = dataReader.GetTimeSpan(0);
                }
               conn.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            
                 
            
            return result;
        }
        public TimeSpan totalHours(int workerId)
        {
            return getSumHours(workerId, "", "");
        }
       
        public bool startTime(int workerId)
        {
            bool result = false;
            try
            {
                MySqlConnection conn = checkConection();
                string sql = "insert into horarios (hora_e,funcionario_id)values(now()," + workerId + ");";
                
                MySqlCommand comand = new MySqlCommand(sql, conn);
                if (comand.ExecuteNonQuery() == 1)
                    result = true;
                conn.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return result;
        }
        public bool endTime(int workerId, string endTime)
        {
            bool result = false;
            try
            {
                MySqlConnection conn = checkConection();
                string sql = "update horarios set hora_s="+endTime+" where  hora_s is null and funcionario_id="+workerId+" and date(hora_e)=date("+endTime+")";
                MySqlCommand comand = new MySqlCommand(sql, conn);
                if (comand.ExecuteNonQuery() == 1)
                    result = true;
                conn.Close();

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return result;
        }
        public bool endTime(int workerId)
        {
            return endTime(workerId, "now()");
        }
        public bool timeCorrection(int horaId,string startTime,string endTime)
        {
            bool result = false;
            try
            {
                MySqlConnection conn = checkConection();
                string sql = "update horarios set hora_s='" + endTime + "',hora_e='"+startTime+"' where  hora_id = "+horaId+"";
                MySqlCommand comand = new MySqlCommand(sql, conn);
                if (comand.ExecuteNonQuery() == 1)
                    result = true;
                conn.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return result;
        }
        public List<Hours> getAllHourInPeriod(int workerId,string startTime,string endTime)
        {
            List<Hours> listHours = new List<Hours>();
            try
            {
                MySqlConnection conn = checkConection();
                string sql = "select * from horarios where funcionario_id= "+workerId+" and hora_e >= '"+startTime+"' and hora_s<= '"+endTime+"';";
                MySqlCommand comand = new MySqlCommand(sql, conn);
                MySqlDataReader dataReader = comand.ExecuteReader();
                while(dataReader.Read())
                {
                    Hours h = new Hours();
                    h.Start = (DateTime)dataReader[1];
                    h.End = (DateTime)dataReader[2];
                    h.WorkerId = workerId;
                    h.Id = (int)dataReader[0];
                    listHours.Add(h);
                }
                conn.Close();

            }
            catch(Exception erro)
            { throw erro; }
            
            return listHours;
        }
        public bool checkExistHourId(int hourId)
        {
            bool result = false;
            try
            {
                MySqlConnection conn = checkConection();
                string sql = "select count(hora_id) from horarios where hora_id= " + hourId+";";
                MySqlCommand comand = new MySqlCommand(sql, conn);
                MySqlDataReader dataReader = comand.ExecuteReader();
                if (dataReader.Read())
                {
                    int res = dataReader.GetInt32(0);
                    if (res == 1)
                        result = true;
                }
                conn.Close();

            }
            catch (Exception erro)
            { throw erro; }

            return result;
        }
        public void restoreDbFromFile(Period period)
        {
            People worker = period.Worker;
            List<Hours> hours = period.ListHours;
            if(this.getWorker(worker.Id)==null)
            {
                try
                {
                    string active = "y";
                    if(!worker.Active)
                        active = "n";
                    string sql = "insert into funcionarios (funcionario_id,funcionario_nome,funcionario_foto,funcionario_ativo) values ("+
                        worker.Id+",'"+worker.Name+"','"+worker.PhotoName+"','"+active+"')";
                    MySqlConnection conn = this.checkConection();
                    MySqlCommand comand = new MySqlCommand(sql,conn);
                    comand.ExecuteNonQuery();
                    conn.Close();
                }
                catch(Exception erro)
                {
                    throw erro;
                }
               
            }
            if(this.getPeriod(worker.Id,period.Id)==null)
            {
                try
                {
                    string sql = "";
                    if(period.Status=='n')
                        sql = "insert into periodos (periodo_id,periodo_inicio,funcionario_id) values (" +
                       period.Id + ",'" + period.StartDate.ToString("yyyy-MM-dd HH:mm:ss") + "'," + period.WorkerId + ")";
                    else
                        sql = "insert into periodos (periodo_id,periodo_inicio,periodo_fim,periodo_data_pagamento,funcionario_id,periodo_status,periodo_valor_hora) values (" +
                        period.Id + ",'" + period.StartDate.ToString("yyyy-MM-dd HH:mm:ss") + "','" + period.EndDate.ToString("yyyy-MM-dd HH:mm:ss") + "','" + period.PayDate.ToString("yyyy-MM-dd") + "',"+period.WorkerId+",'y',"+period.ValueHour+")";
                    MySqlConnection conn = this.checkConection();
                    MySqlCommand comand = new MySqlCommand(sql, conn);
                    comand.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception erro)
                {
                    throw erro;
                }
            }
            foreach (Hours hour in hours)
            {
                if (!this.checkExistHourId(hour.Id))
                {
                    try
                    {

                        string sql = "insert into horarios (hora_id,hora_e,hora_s,funcionario_id) values (" +
                            hour.Id + ",'" + hour.Start.ToString("yyyy-MM-dd HH:mm:ss") + "','" + hour.End.ToString("yyyy-MM-dd HH:mm:ss") + "'," +hour.WorkerId+ ")";
                        MySqlConnection conn = this.checkConection();
                        MySqlCommand comand = new MySqlCommand(sql, conn);
                        comand.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception erro)
                    {
                        throw erro;
                    }
                }
            }
        }
        
    }   
}

