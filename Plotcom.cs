// <project>Latent Dirichlet Allocation(LDA) Project</project>
// <author>George K Yu</author>
// <date>08/04/2015</date>

using System;
using System.Data;
using System.Configuration;
using System.Web;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace DLAProj
{
    /// <summary>
    /// Summary Description for Plotting Common Functions
    /// </summary>
    public class Plotcom
    {        
        public static int NullInt = int.MinValue;

        public Plotcom()
        {            
        }

        public OracleConnection getConnection()
        {
            OracleConnection oracleConn = new OracleConnection();
            String connStr = ConfigurationManager.ConnectionStrings["OracleDBConnectionString"].ConnectionString;
            oracleConn.ConnectionString = connStr;

            return oracleConn;
        }
        

        public OracleDataReader getDocTopicDistByTopicNumberList(List<string> list_topic_num)
        {
            string str_topic_list = "";

            foreach (string topic_num in list_topic_num)
            {
                str_topic_list += "ROUND(sum(t" + topic_num + ")/GET_NUM_OF_DATE(datecol), 8) as T" + topic_num + ", ";

            }

            string strSQLQuery = "select " + str_topic_list + "datecol from DOCUMENT_TOPIC_DISTRIBUTIONS group by datecol order by datecol";

            StringBuilder sb = new StringBuilder();

            OracleConnection oConn = getConnection();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = oConn;
            cmd.CommandText = strSQLQuery;

            cmd.Connection.Open();
            OracleDataReader objDataReader = cmd.ExecuteReader();

            return objDataReader;
        }

        public OracleDataReader getAllDocTopicDist()
        {

            string strSQLQuery = "select " +
                    "ROUND(sum(t0)/GET_NUM_OF_DATE(datecol), 8) as T0,  " + 
                    "ROUND(sum(t1)/GET_NUM_OF_DATE(datecol), 8) as T1,  " + 
                    "ROUND(sum(t2)/GET_NUM_OF_DATE(datecol), 8) as T2,  " +
                    "ROUND(sum(t3)/GET_NUM_OF_DATE(datecol), 8) as T3,  " +
                    "ROUND(sum(t4)/GET_NUM_OF_DATE(datecol), 8) as T4,  " +
                    "ROUND(sum(t5)/GET_NUM_OF_DATE(datecol), 8) as T5,  " +
                    "ROUND(sum(t6)/GET_NUM_OF_DATE(datecol), 8) as T6,  " +
                    "ROUND(sum(t7)/GET_NUM_OF_DATE(datecol), 8) as T7,  " +
                    "ROUND(sum(t8)/GET_NUM_OF_DATE(datecol), 8) as T8,  " +
                    "ROUND(sum(t9)/GET_NUM_OF_DATE(datecol), 8) as T9,  " +
                    "ROUND(sum(t10)/GET_NUM_OF_DATE(datecol), 8) as T10,  " +
                    "ROUND(sum(t11)/GET_NUM_OF_DATE(datecol), 8) as T11,  " + 
                    "ROUND(sum(t12)/GET_NUM_OF_DATE(datecol), 8) as T12,  " + 
                    "ROUND(sum(t13)/GET_NUM_OF_DATE(datecol), 8) as T13,  " + 
                    "ROUND(sum(t14)/GET_NUM_OF_DATE(datecol), 8) as T14,  " + 
                    "ROUND(sum(t15)/GET_NUM_OF_DATE(datecol), 8) as T15,  " + 
                    "ROUND(sum(t16)/GET_NUM_OF_DATE(datecol), 8) as T16,  " + 
                    "ROUND(sum(t17)/GET_NUM_OF_DATE(datecol), 8) as T17,  " + 
                    "ROUND(sum(t18)/GET_NUM_OF_DATE(datecol), 8) as T18,  " + 
                    "ROUND(sum(t19)/GET_NUM_OF_DATE(datecol), 8) as T19,  " +
                    "ROUND(sum(t20)/GET_NUM_OF_DATE(datecol), 8) as T20,  " + 
                    "ROUND(sum(t21)/GET_NUM_OF_DATE(datecol), 8) as T21,  " + 
                    "ROUND(sum(t22)/GET_NUM_OF_DATE(datecol), 8) as T22,  " + 
                    "ROUND(sum(t23)/GET_NUM_OF_DATE(datecol), 8) as T23,  " + 
                    "ROUND(sum(t24)/GET_NUM_OF_DATE(datecol), 8) as T24,  " + 
                    "ROUND(sum(t25)/GET_NUM_OF_DATE(datecol), 8) as T25,  " + 
                    "ROUND(sum(t26)/GET_NUM_OF_DATE(datecol), 8) as T26,  " + 
                    "ROUND(sum(t27)/GET_NUM_OF_DATE(datecol), 8) as T27,  " + 
                    "ROUND(sum(t28)/GET_NUM_OF_DATE(datecol), 8) as T28,  " + 
                    "ROUND(sum(t29)/GET_NUM_OF_DATE(datecol), 8) as T29,  " + 
                    "ROUND(sum(t30)/GET_NUM_OF_DATE(datecol), 8) as T30,  " + 
                    "ROUND(sum(t31)/GET_NUM_OF_DATE(datecol), 8) as T31,  " + 
                    "ROUND(sum(t32)/GET_NUM_OF_DATE(datecol), 8) as T32,  " + 
                    "ROUND(sum(t33)/GET_NUM_OF_DATE(datecol), 8) as T33,  " + 
                    "ROUND(sum(t34)/GET_NUM_OF_DATE(datecol), 8) as T34,  " + 
                    "ROUND(sum(t35)/GET_NUM_OF_DATE(datecol), 8) as T35,  " + 
                    "ROUND(sum(t36)/GET_NUM_OF_DATE(datecol), 8) as T36,  " + 
                    "ROUND(sum(t37)/GET_NUM_OF_DATE(datecol), 8) as T37,  " + 
                    "ROUND(sum(t38)/GET_NUM_OF_DATE(datecol), 8) as T38,  " + 
                    "ROUND(sum(t39)/GET_NUM_OF_DATE(datecol), 8) as T39,  " + 
                    "ROUND(sum(t40)/GET_NUM_OF_DATE(datecol), 8) as T40,  " + 
                    "ROUND(sum(t41)/GET_NUM_OF_DATE(datecol), 8) as T41,  " + 
                    "ROUND(sum(t42)/GET_NUM_OF_DATE(datecol), 8) as T42,  " + 
                    "ROUND(sum(t43)/GET_NUM_OF_DATE(datecol), 8) as T43,  " + 
                    "ROUND(sum(t44)/GET_NUM_OF_DATE(datecol), 8) as T44,  " + 
                    "ROUND(sum(t45)/GET_NUM_OF_DATE(datecol), 8) as T45,  " + 
                    "ROUND(sum(t46)/GET_NUM_OF_DATE(datecol), 8) as T46,  " + 
                    "ROUND(sum(t47)/GET_NUM_OF_DATE(datecol), 8) as T47,  " + 
                    "ROUND(sum(t48)/GET_NUM_OF_DATE(datecol), 8) as T48,  " + 
                    "ROUND(sum(t49)/GET_NUM_OF_DATE(datecol), 8) as T49,  " +
                    "datecol from DOCUMENT_TOPIC_DISTRIBUTIONS group by datecol order by datecol";


            StringBuilder sb = new StringBuilder();

            OracleConnection oConn = getConnection();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = oConn;
            cmd.CommandText = strSQLQuery;

            cmd.Connection.Open();
            OracleDataReader objDataReader = cmd.ExecuteReader();

            return objDataReader;
        }

        public OracleDataReader getAllTopics()
        {

            string strSQLQuery = "select * from DOCUMENT_TOPICS order by topic";

            StringBuilder sb = new StringBuilder();

            OracleConnection oConn = getConnection();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = oConn;
            cmd.CommandText = strSQLQuery;

            cmd.Connection.Open();
            OracleDataReader objDataReader = cmd.ExecuteReader();

            return objDataReader;
        }

         public DataSet getAllTopicsDS(OracleDataReader reader)
        {
            return ConvertDataReaderToDataSet(reader);
        }

         public void updateColorByTopicID(int topicID, string colorname)
         {
             string sqlStatement = "update DOCUMENT_TOPICS set COLOR = :COLOR where TOPIC =:TOPIC";
             ExecuteNonQuery(sqlStatement,
                 CreateParameter(":COLOR", OracleDbType.Varchar2, colorname),
                 CreateParameter(":TOPIC", OracleDbType.Int16, topicID));
         }

         public string getColorByTopicID(int topicID)
         {   
             string sqlStatement = "select color from DOCUMENT_TOPICS where TOPIC =:TOPIC";
             return ExecuteScalar(sqlStatement, CreateParameter(":TOPIC", OracleDbType.Int16, topicID));
         }

         public string getTopicWordsByTopicID(int topicID)
         {
             string sqlStatement = "select words from DOCUMENT_TOPICS where TOPIC =:TOPIC";
             return ExecuteScalar(sqlStatement, CreateParameter(":TOPIC", OracleDbType.Int16, topicID));
         }

        public DataSet ConvertDataReaderToDataSet(OracleDataReader reader)
        {
            DataTable mydt = new DataTable();
            DataSet mydataSet = new DataSet();
            mydt.Load(reader);
            mydataSet.Tables.Add(mydt);

            for (int i = 0; i < mydataSet.Tables[0].Rows.Count; i++)
            {
                //tokenize it by the bar delimiter
                string[] lines = Regex.Split(mydataSet.Tables[0].Rows[i]["WORDS"].ToString(), @"\d+\|");

                string wordslist = "";
                foreach (string s in lines)
                {
                    wordslist += s;
                }                

                if (wordslist.Length > 215) wordslist = wordslist.Substring(0, 215) + "..";
                //if there is a comma at the end replace it with space
                string regpattern = @",\w*(..)?$|,$";                
                wordslist = Regex.Replace(wordslist, regpattern, " ");

                mydataSet.Tables[0].Rows[i]["WORDS"] = "T" + mydataSet.Tables[0].Rows[i]["TOPIC"] + ":" + wordslist;
            }
            return mydataSet;
        }

        protected string ExecuteScalar(string sqlQuery,
            params IDataParameter[] procParams)
        {
            OracleCommand cmd;
            return ExecuteScalar(out cmd, sqlQuery, procParams);
        }

        protected string ExecuteScalar(out OracleCommand cmd, string sqlQuery,
            params IDataParameter[] procParams)
        {
            OracleConnection cnx = getConnection();
            string myresult = "";
            cmd = null;

            try
            {
                cmd = new OracleCommand(sqlQuery);
                cmd.CommandType = CommandType.Text;
                if (procParams != null)
                {
                    for (int index = 0; index < procParams.Length; index++)
                    {
                        cmd.Parameters.Add(procParams[index]);
                    }
                }

                cmd.Connection = cnx;
                cnx.Open();

                if (cmd.ExecuteScalar() != null)
                {
                    myresult = cmd.ExecuteScalar().ToString();
                }

            }
            catch (Exception e)
            {                
                throw e;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                 cnx.Dispose(); 
            }
            return myresult;
        }

        protected DataSet ExecuteDataSet(string sqlQuery,
            params IDataParameter[] procParams)
        {
            OracleCommand cmd;
            return ExecuteDataSet(out cmd, sqlQuery, procParams);
        }


        protected DataSet ExecuteDataSet(out OracleCommand cmd, string sqlQuery,
            params IDataParameter[] procParams)
        {
            OracleConnection cnx = getConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            cmd = null;

            try
            {
                cmd = new OracleCommand(sqlQuery);
                cmd.CommandType = CommandType.Text;
                if (procParams != null)
                {
                    for (int index = 0; index < procParams.Length; index++)
                    {
                        cmd.Parameters.Add(procParams[index]);
                    }
                }
                da.SelectCommand = (OracleCommand)cmd;

                cmd.Connection = cnx;
                cnx.Open();
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (da != null) da.Dispose();
                if (cmd != null) cmd.Dispose();
                cnx.Dispose();
            }
            return ds;
        }

        protected void ExecuteNonQuery(string sqlQuery, params IDataParameter[] procParams)
        {
            OracleCommand cmd;
            ExecuteNonQuery(out cmd, sqlQuery, procParams);
        }

        protected void ExecuteNonQuery(out OracleCommand cmd, string sqlQuery, params IDataParameter[] procParams)
        {
            OracleConnection cnx = getConnection();
            cmd = null;

            try
            {
                cmd = new OracleCommand(sqlQuery);
                cmd.CommandType = CommandType.Text;

                for (int index = 0; index < procParams.Length; index++)
                {
                    cmd.Parameters.Add(procParams[index]);
                }

                cmd.Connection = cnx;
                cnx.Open();
                
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnx.Dispose();
                if (cmd != null) cmd.Dispose();
            }
        }

        protected OracleParameter CreateParameter(string paramName,
         OracleDbType paramType, object paramValue)
        {
            OracleParameter param = new OracleParameter(paramName, paramType);

            if (paramValue != DBNull.Value)
            {
                switch (paramType)
                {
                    case OracleDbType.Varchar2:
                    case OracleDbType.NVarchar2:
                    case OracleDbType.Char:
                    case OracleDbType.NChar:
                        paramValue = CheckParamValue((string)paramValue);
                        break;
                    case OracleDbType.Int32:
                        paramValue = CheckParamValue((int)paramValue);
                        break;
                    case OracleDbType.Int16:
                        paramValue = CheckParamValue((int)paramValue);
                        break;
                }
            }
            param.Value = paramValue;
            return param;
        }

        protected object CheckParamValue(string paramValue)
        {
            if (string.IsNullOrEmpty(paramValue))
            {
                return DBNull.Value;
            }
            else
            {
                return paramValue;
            }
        }

        protected object CheckParamValue(int paramValue)
        {
            if (paramValue.Equals(NullInt))
            {
                return DBNull.Value;
            }
            else
            {
                return paramValue;
            }
        }
     
    }
}