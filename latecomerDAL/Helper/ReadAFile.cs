using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using System.Xml;
using System.Data;
using System.IO;

namespace latecomerDAL.Helper
{
    public class ReadAFile
    {
        public string FilePath { get; set; }

        #region constructor

        public ReadAFile()
        {
            this.FilePath = @"c:\Users\jkeedhoo\Documents\Visual Studio 2013\Projects\latecomerDAL\latecomerDAL\LatecomerDocument.XML";
        }

        public ReadAFile(string filePathName)
        {
            this.FilePath = filePathName;
        }

        #endregion

        public List<AttendanceForm> ReadXMLFile()
        {
            List<AttendanceForm> newLatecomerList = new List<AttendanceForm>();
            DataSet ds = null;
            try
            {
                string xmlFile = this.FilePath;

                ds = new DataSet();

                ds.ReadXml(xmlFile);

                foreach (DataRow row in ds.Tables[0].AsEnumerable())
                {
                    AttendanceForm tempLatecomer = new AttendanceForm();
                    tempLatecomer.studentID = row.Field<string>("StudentID");
                    tempLatecomer.arrivalTime = row.Field<string>("TimeArrived");
                    newLatecomerList.Add(tempLatecomer);
                }

            }

            catch (FileNotFoundException)
            { }

            catch (Exception)
            { }

            finally
            {
                if (ds != null)
                {
                    ds.Clear();
                }
            }
            return newLatecomerList;
        }
    }
}
