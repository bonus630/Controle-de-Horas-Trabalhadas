using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//using Ex = Microsoft.Office.Interop.Excel;

namespace br.corp.bonus630.ControleHorasTrabalhadas.Controllers
{
    public static class SaveLoad
    {
        public static void save(string filename, Period period)
        {
            if (File.Exists(filename))
                File.Delete(filename);
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            BinaryFormatter binFormatter = new BinaryFormatter();
            binFormatter.Serialize(fs, period);
            fs.Close();
        }
        public static Period load(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            BinaryFormatter binFormatter = new BinaryFormatter();
            object obj = binFormatter.Deserialize(fs);
            fs.Close();
            return (Period)obj;
        }
        //public static void exportExcel(string filename,Period period)
        //{

        //    Ex.Application xl = new Ex.Application();
        //    object misValue = System.Reflection.Missing.Value;
        //    Ex.Workbook workbook = xl.Workbooks.Add(misValue);
        //    Ex.Worksheet worksheet = (Ex.Worksheet)workbook.Worksheets.get_Item(1);
        //    worksheet.Cells[1, 1] = "Dia da semana";
        //    worksheet.Cells[1, 2] = "Data";
        //    worksheet.Cells[1, 3] = "Hora Entrada";
        //    worksheet.Cells[1, 4] = "Hora Saída";
        //    worksheet.Cells[1, 5] = "Tempo Trabalhado";
        //    for(int i = 0;i<period.ListHours.Count;i++)
        //    {
        //        int linePos = i + 2;
        //        Hours temp = period.ListHours[i];
        //        worksheet.Cells[linePos, 1] = temp.DayOfWeek;
        //        worksheet.Cells[linePos, 2] =temp.Start.ToShortDateString();
        //        worksheet.Cells[linePos, 3] = temp.Start.ToLongTimeString();
        //        worksheet.Cells[linePos, 4] = temp.End.ToLongTimeString();
        //        worksheet.Cells[linePos,4]
        //        worksheet.Cells[linePos, 5] = temp.End.Subtract(temp.Start).Hours;
        //    }
        //    workbook.SaveAs((object)filename,Ex.XlFileFormat.xlExcel12, misValue,misValue,false,false,Ex.XlSaveAsAccessMode.xlExclusive,false,false,misValue,misValue,misValue);
        //    workbook.Close(true, filename, misValue);
        //    xl.Quit();
        //    releaseComObjects(worksheet);
        //    releaseComObjects(workbook);
        //    releaseComObjects(xl);
        //}
        //private static void releaseComObjects(object obj)
        //{
        //    try
        //    {
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
        //        obj = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        obj = null;
              
        //    }
        //    finally
        //    {
        //        GC.Collect();
        //    }
        //}
    }
}
