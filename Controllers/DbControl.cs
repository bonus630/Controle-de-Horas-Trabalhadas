using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.ComponentModel;


namespace br.corp.bonus630.ControleHorasTrabalhadas.Controllers
{
    public class DbControl
    {
       
        private string connectionString;
        private MySqlConnection conn;
        public static string dbserver;
        public static string dbuser;
        public static string dbpassword;

        public static void setStringConnection(string dbserver, string dbuser, string dbpassword)
        {
            DbControl.dbserver = dbserver;
            DbControl.dbuser = dbuser;
            DbControl.dbpassword = dbpassword;
        }

        public DbControl()
        {

        }
        private void checkConnection()
        {
            connectionString = string.Format("Persist Security Info=False;server={0};user={1};database=controle_horas_trabalhadas;port=3306;password={2};",DbControl.dbserver,DbControl.dbuser,DbControl.dbpassword);
            if(conn==null)
                conn =  new MySqlConnection(connectionString);
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
            //return conn;
        }
        private void closeConnection()
        {
            if(conn!=null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
        public bool checkMysql()
        {
            try
            {
                this.checkConnection();
                
                conn.Close();
                return true;
            }
            catch{return false;}
}
        //public List<People> getAllWorkers()
        public BindingList<People> getAllWorkers()
        {
            BindingList<People> workers = new BindingList<People>();
            try
            {
                this.checkConnection();
                
                string sql = "select * from funcionarios where funcionario_id > 1 order by funcionario_ativo desc";
                MySqlCommand comand = new MySqlCommand(sql, conn);
                using (MySqlDataReader dataReader = comand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        //workers.Add(new People((int)dataReader[0], (string)dataReader[1], (string)dataReader[2], (string)dataReader[3], this.isWork((int)dataReader[0])));
                        //People temp = new People();
                        //temp.Id = (int)dataReader[0];
                        //temp.Name = (string)dataReader[1];
                        //temp.PhotoName = (string)dataReader[2];
                        //temp.Active = (string)dataReader[3];
                        workers.Add(new People((int)dataReader[0], (string)dataReader[1], (string)dataReader[2], (string)dataReader[3], false));
                    }
                }
                
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                this.closeConnection();
            }
            foreach (People item in workers)
            {
                item.Working = this.isWork(item.Id);
            }
            return workers;
        }
        public int getLastWorkId()
        {
            int result = -1;
            try
            {
                this.checkConnection();
                string sql = "select funcionario_id from funcionarios order by funcionario_id desc limit 1";
                MySqlCommand comand = new MySqlCommand(sql, conn);
                MySqlDataReader dataReader = comand.ExecuteReader();
               
                if (dataReader.Read())
                {
                    result = dataReader.GetInt32(0);
                }
                
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                this.closeConnection();
            }
            
            return result;
        }
        public DateTime getFirstDatePeriod(int worker,string status,bool first)
        {
            DateTime result = new DateTime();
            try
            {
                this.checkConnection();
                string condition = "";
                if (!string.IsNullOrEmpty(status))
                    condition = string.Format(" and periodo_status='{0}'",status);
                string sql = "";
                if (first)
                    sql = string.Format("select periodo_inicio from periodos where funcionario_id={0}{1} order by periodo_id asc limit 1",worker, condition);
                else
                    sql = string.Format("select periodo_fim from periodos where funcionario_id={0}{1} order by periodo_id desc limit 1", worker,condition);
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
                
                
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                this.closeConnection();
            }
            return result;
        }
        private List<Period> getPeriods(int worker,string condition)
        {
            List<Period> periods = new List<Period>();
            try 
            {
                this.checkConnection();
                string sql =string.Format("select * from periodos where funcionario_id={0}{1}",worker,condition);
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
                
            }
            catch(Exception erro)
            {
                throw erro;
            }
            finally
            {
                this.closeConnection();
            }
            
            return periods;
        }
        public List<Period> getPayPeriods(int worker)
        {
            return this.getPeriods(worker, " and periodo_status='y'");
        }
        public List<Period> getPayPeriodsInInterval(int worker,string startDate,string endDate)
        {
            return this.getPeriods(worker, string.Format(" and periodo_status='y' and date(periodo_inicio) >= '{0}' and date(periodo_fim) <= '{1}'", startDate, endDate));
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
            List<Period> periods = this.getPeriods(worker, string.Format(" and periodo_id={0}",periodId));
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
                this.checkConnection();

                string sql = string.Format("select periodo_id from periodos where funcionario_id={0} and periodo_status='n'",workerId);
                MySqlCommand comand = new MySqlCommand(sql, conn);
                MySqlDataReader dataReader = comand.ExecuteReader();
                if (dataReader.Read())
                {
                    
                    result = (int)dataReader[0];
                }
                
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                this.closeConnection();
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
                    string sql = string.Format("insert into periodos (periodo_inicio,funcionario_id) values('{0}',{1});",dateStart,workerId);
                    this.checkConnection();
                    MySqlCommand comand = new MySqlCommand(sql, conn);
                    //MySqlDataReader dataReader = comand.ExecuteReader();
                    int result = comand.ExecuteNonQuery();
                    
                }
                catch (Exception erro)
                {
                    throw erro;
                }
                finally
                {
                    this.closeConnection();
                }
            }
            
        }
        private DateTime getLastHourFromDate(DateTime date, int workerId)
        {
            DateTime result = new DateTime();
            try
            {
                
                string sql = string.Format("select hora_s from horarios where funcionario_id=1003 and date(hora_s)<='{0}' order by hora_s desc limit 1;", date.ToString("yyyy-MM-dd"));
                this.checkConnection();
                MySqlCommand comand = new MySqlCommand(sql, conn);
                // comand.Connection = conn;
                //  comand.CommandText = sql;
                //  comand.Prepare();
                //   comand.Parameters.AddWithValue("@dateFinalValue", date);
                MySqlDataReader dataReader = comand.ExecuteReader();
                if (dataReader.Read())
                {
                    result = (DateTime)dataReader.GetDateTime(0);
                }
                
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                this.closeConnection();
            }
            return result;
            
        }
        public bool setPayPeriod(int periodId,int workerId,DateTime dateEnd,decimal hourValue)
        {
            bool ret = false;
            try
            {
                DateTime finalDate = getLastHourFromDate(dateEnd, workerId);
               
                string dateEndString = dateEnd.Date.ToString("yyyy-MM-dd");
                this.checkConnection();
               // MySqlParameter parameterHourValue = new MySqlParameter(":hourValue", MySqlDbType.Decimal);
              //  parameterHourValue.Value = hourValue;
              //  MySqlParameterCollection parameters = new MySqlParameterCollection();
              //  parameters.Add(parameterHourValue);
                string sql = string.Format("update periodos set periodo_status='y',periodo_fim='{0}',periodo_data_pagamento=now(),periodo_valor_hora=@hourValue where periodo_id={1};",finalDate.ToString("yyyy-MM-dd HH:mm:ss"),periodId);
                
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
                    
                    ret = true;
                }

            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                this.closeConnection();
            }
            
            return ret;

        }
        public bool insertWorker(People worker)
        {
            bool ret = false;
            try
            {
                this.checkConnection();
                string sql = string.Format("insert into funcionarios (funcionario_nome,funcionario_foto,funcionario_ativo)values('{0}','{1}','y');",worker.Name,worker.PhotoName);
                MySqlCommand comand = new MySqlCommand(sql, conn);
                int result = comand.ExecuteNonQuery();
                if (result == 1)
                {
                    
                    ret = true;
                }

            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                this.closeConnection();
            }
          
            return ret;
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
            People worker = null;
            try
            {
                this.checkConnection();
                string sql =  string.Format("select * from funcionarios where funcionario_id = {0};",workerId);
                MySqlCommand comand = new MySqlCommand(sql, conn);
                MySqlDataReader dataReader = comand.ExecuteReader();
                if (dataReader.Read())
                {
                   // worker = new People((int)dataReader[0], (string)dataReader[1], (string)dataReader[2], (string)dataReader[3], this.isWork((int)dataReader[0]));
                    worker = new People((int)dataReader[0], (string)dataReader[1], (string)dataReader[2], (string)dataReader[3], false); 
                  
                }
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                this.closeConnection();
            }
            if(worker != null)
                worker.Working = this.isWork(worker.Id);
            return worker;
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
                this.checkConnection();
                string sql = string.Format("select hora_id, hora_e,funcionario_id from horarios where funcionario_id = {0} and hora_s is null;",workerId);
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
                
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                this.closeConnection();
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
                this.checkConnection();
               //Antiga consulta
                //string sql = "select hora_id, hora_e,hora_s from horarios where funcionario_id = " + workerId + " and hora_s is not null and date(hora_e)>='" + dateTimeStart + "'";
                //Nova consulta para testar ainda
                string sql = string.Format("select hora_id, hora_e,hora_s from horarios where funcionario_id = {0} and hora_s is not null and hora_e>='{1}'",workerId,dateTimeStart);
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
                
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                this.closeConnection();
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
                this.checkConnection();
                string sql =
string.Format("select hora_e from horarios where  hora_s is null and funcionario_id={0} and date(hora_e)=date(now());", workerId);
                MySqlCommand comand = new MySqlCommand(sql, conn);
                MySqlDataReader dataReader = comand.ExecuteReader();
               
                if (dataReader.Read())
                {
                    result = true;
                   

                }
               
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                this.closeConnection();
            }
                
            
             return result;
        }
        public bool editWorker(People worker)
        {
            bool result = false;
            try
            {
               this.checkConnection();
                string ative = "n";
                if(worker.Active)
                    ative = "y";
                string sql = string.Format("update funcionarios set funcionario_nome='{0}',funcionario_foto='{1}',funcionario_ativo='{2}' where funcionario_id={3};",worker.Name,worker.PhotoName,ative,worker.Id);
                MySqlCommand comand = new MySqlCommand(sql, conn);
              
                if (comand.ExecuteNonQuery() == 1)
                    result = true;
                
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                this.closeConnection();
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
                this.checkConnection();
                string sql =
                    string.Format("select sec_to_time(sum(TIME_TO_SEC(hora_s) - time_to_sec(hora_e))) as Total from horarios where funcionario_id= {0} and date(hora_e)>='{1}'",workerId,dateTimeStart);
                if(!string.IsNullOrEmpty(dateTimeEnd))
                    sql+= " and date(hora_s) <= '" + dateTimeEnd + "';";
                MySqlCommand comand = new MySqlCommand(sql, conn);
                MySqlDataReader dataReader = comand.ExecuteReader();

                if (dataReader.Read()&& !dataReader.IsDBNull(0))
                {
                    result = dataReader.GetTimeSpan(0);
                }
               
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                this.closeConnection();
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
                this.checkConnection();
                string sql = string.Format("insert into horarios (hora_e,funcionario_id)values(now(),{0});",workerId);
                
                MySqlCommand comand = new MySqlCommand(sql, conn);
                if (comand.ExecuteNonQuery() == 1)
                    result = true;
                ;
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                this.closeConnection();
            }
            return result;
        }
        public bool endTime(int workerId, string endTime)
        {
            bool result = false;
            try
            {
                this.checkConnection();
                string sql = string.Format("update horarios set hora_s={0} where  hora_s is null and funcionario_id={1} and date(hora_e)=date({0})", endTime,workerId);
                MySqlCommand comand = new MySqlCommand(sql, conn);
                if (comand.ExecuteNonQuery() == 1)
                    result = true;
               

            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                this.closeConnection();
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
                this.checkConnection();
                string sql = string.Format("update horarios set hora_s='{0}',hora_e='{1}' where  hora_id = {2}", endTime, startTime, horaId);
                MySqlCommand comand = new MySqlCommand(sql, conn);
                if (comand.ExecuteNonQuery() == 1)
                    result = true;
               
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                this.closeConnection();
            }
            return result;
        }
        public List<Hours> getAllHourInPeriod(int workerId,string startTime,string endTime)
        {
            List<Hours> listHours = new List<Hours>();
            try
            {
                this.checkConnection();
                string sql = string.Format("select * from horarios where funcionario_id= {0} and hora_e >= '{1}' and hora_s<= '{2}';",workerId,startTime,endTime);
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
                

            }
            catch(Exception erro)
            { throw erro; }
            finally
            {
                this.closeConnection();
            }
            
            return listHours;
        }
        public bool checkExistHourId(int hourId)
        {
            bool result = false;
            try
            {
                this.checkConnection();
                string sql = string.Format("select count(hora_id) from horarios where hora_id= {0};",hourId);
                MySqlCommand comand = new MySqlCommand(sql, conn);
                MySqlDataReader dataReader = comand.ExecuteReader();
                if (dataReader.Read())
                {
                    int res = dataReader.GetInt32(0);
                    if (res == 1)
                        result = true;
                }
                

            }
            catch (Exception erro)
            { throw erro; }
            finally
            {
                this.closeConnection();
            }

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
                    string sql = string.Format("insert into funcionarios (funcionario_id,funcionario_nome,funcionario_foto,funcionario_ativo) values ({0},'{1}','{2}','{3}');",worker.Id,worker.Name,worker.PhotoName,active);
                    this.checkConnection();
                    MySqlCommand comand = new MySqlCommand(sql,conn);
                    comand.ExecuteNonQuery();
                    
                }
                catch(Exception erro)
                {
                    throw erro;
                }
                finally
                {
                    this.closeConnection();
                }
            }
            if(this.getPeriod(worker.Id,period.Id)==null)
            {
                try
                {
                    string sql = "";
                    if(period.Status=='n')
                        sql = string.Format("insert into periodos (periodo_id,periodo_inicio,funcionario_id) values ({0},'{1}','{2}');",
                       period.Id,period.StartDate.ToString("yyyy-MM-dd HH:mm:ss"),period.WorkerId);
                    else
                        sql = string.Format("insert into periodos (periodo_id,periodo_inicio,periodo_fim,periodo_data_pagamento,funcionario_id,periodo_status,periodo_valor_hora) values ({0},'{1}','{2}','{3}',{4},'y',{5});",
                        period.Id,period.StartDate.ToString("yyyy-MM-dd HH:mm:ss"), period.EndDate.ToString("yyyy-MM-dd HH:mm:ss"),period.PayDate.ToString("yyyy-MM-dd"),period.WorkerId,period.ValueHour);
                    this.checkConnection();
                    MySqlCommand comand = new MySqlCommand(sql, conn);
                    comand.ExecuteNonQuery();
                    
                }
                catch (Exception erro)
                {
                    throw erro;
                }
                finally
                {
                    this.closeConnection();
                }
            }
            foreach (Hours hour in hours)
            {
                if (!this.checkExistHourId(hour.Id))
                {
                    try
                    {
                        string sql = "";
                        if (hour.End == Period.INVALIDDATE)
                        {
                            sql = string.Format("insert into horarios (hora_id,hora_e,funcionario_id) values ({0},'{1}',{2});",
                               hour.Id,hour.Start.ToString("yyyy-MM-dd HH:mm:ss"),hour.WorkerId);
                        }
                        else
                        {
                            sql = string.Format("insert into horarios (hora_id,hora_e,hora_s,funcionario_id) values ({0},'{1}','{2}',{3});",
                               hour.Id,hour.Start.ToString("yyyy-MM-dd HH:mm:ss"),hour.End.ToString("yyyy-MM-dd HH:mm:ss"),hour.WorkerId);
                        }
                        this.checkConnection();
                        MySqlCommand comand = new MySqlCommand(sql, conn);
                        comand.ExecuteNonQuery();
                       
                    }
                    catch (Exception erro)
                    {
                        throw erro;
                    }
                    finally
                    {
                        this.closeConnection();
                    }
                }
            }
        }
        
    }   
}

