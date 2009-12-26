using System;
using System.Collections.Generic;
using System.Web;
using System.Data.OleDb;
using System.Collections;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for ADOAccess
/// </summary>
public class ADOAccess
{
    private string _DataPath;
    private OleDbConnection _Connection;
    private string _PassWord;
    public string PassWord
    {
        set { _PassWord = value; }
        get { return _PassWord; }
    }
    public string DataPath
    {
        get { return _DataPath; }
        set { _DataPath = value; }
    }
    public OleDbConnection Connection
    {
        get { return _Connection; }
    }
    public ADOAccess()
    {
        string _DataPath = ConfigurationManager.ConnectionStrings["DataPath"].ToString();
        if (_DataPath != null)
        {
            _DataPath = HttpContext.Current.Server.MapPath(_DataPath);
        }
        if (_PassWord == null)
            _Connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + _DataPath);
        else
        {
            string constr = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info=false;Jet OLEDB:Database Password={0};Data Source={1}", _PassWord, _DataPath);
            _Connection = new OleDbConnection(constr);
        }
    }
    public ADOAccess(string DataUrl)
    {
        _DataPath = DataUrl.IndexOf("~") == 0 ? HttpContext.Current.Server.MapPath(DataUrl) : DataUrl;
        _Connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + _DataPath);
    }
    public bool Open()
    {
        if (_Connection.State == System.Data.ConnectionState.Closed)
        {
            try
            {
                _Connection.Open();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        return true;

    }
    public void Close()
    {
        if (_Connection.State == System.Data.ConnectionState.Closed)
        {
            _Connection.Close();
        }
    }
    ~ADOAccess()
    {
        this.Close();
    }
    public OleDbDataReader ExecuteReader(string sql)
    {
        return ExecuteReader(sql, null);
    }
    public OleDbDataReader ExecuteReader(string sql, OleDbParameter[] dbParameter)
    {
        if (this.Open())
        {
            try
            {
                OleDbCommand Command = new OleDbCommand(sql, _Connection);
                if (dbParameter != null && dbParameter.Length > 0)
                {
                    foreach (OleDbParameter par in dbParameter)
                    {
                        Command.Parameters.Add(par);
                    }
                }
                OleDbDataReader Reader = Command.ExecuteReader();
                return Reader;
            }
            catch (Exception)
            {

                return null;
            }


        }
        return null;
    }
    public DataSet ExecuteDataSet(string sql, OleDbParameter[] dbParameter, int start, int count)
    {
        if (this.Open())
        {
            try
            {
                OleDbCommand Command = new OleDbCommand(sql, _Connection);
                if (dbParameter != null && dbParameter.Length > 0)
                {
                    foreach (OleDbParameter par in dbParameter)
                    {
                        Command.Parameters.Add(par);
                    }
                }
                OleDbDataAdapter DataAdapter = new OleDbDataAdapter();
                DataAdapter.SelectCommand = Command;
                DataSet ds = new DataSet();
                if (count == 0)
                    DataAdapter.Fill(ds);
                else
                    DataAdapter.Fill(ds, start, count, "ds");
                return ds;
            }
            catch (Exception)
            {

                return null;
            }

        }
        return null;
    }
    public DataSet ExecuteDataSet(string sql)
    {
        return ExecuteDataSet(sql, null, 0, 0);
    }
    public DataSet ExecuteDataSet(string sql, OleDbParameter[] dbParameter)
    {
        return ExecuteDataSet(sql, dbParameter, 0, 0);
    }
    public DataSet ExecuteDataSet(string sql, int start, int count)
    {
        return ExecuteDataSet(sql, null, start, count);
    }
    public int ExecuteCount(string sql, OleDbParameter[] dbParameter)
    {
        if (this.Open())
        {
            try
            {
                OleDbCommand Command = new OleDbCommand(sql, _Connection);
                if (dbParameter != null && dbParameter.Length > 0)
                {
                    foreach (OleDbParameter par in dbParameter)
                    {
                        Command.Parameters.Add(par);
                    }
                }
                return Command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                return 0;
            }

        }
        return 0;
    }
    public int ExecuteCount(string sql)
    {
        return ExecuteCount(sql, null);
    }
    public object ExecuteScalar(string sql, OleDbParameter[] dbParameter)
    {
        if (this.Open())
        {
            try
            {
                OleDbCommand Command = new OleDbCommand(sql, _Connection);
                if (dbParameter != null && dbParameter.Length > 0)
                {
                    foreach (OleDbParameter par in dbParameter)
                    {
                        Command.Parameters.Add(par);
                    }
                }
                return Command.ExecuteScalar();
            }
            catch (Exception)
            {

                return null;
            }
        }
        return null;
    }
    public object ExecuteScalar(string sql)
    {
        return ExecuteScalar(sql, null);
    }
    public OleDbCommand NewCommand
    {
        get
        {
           OleDbCommand Command =new OleDbCommand();
           Command.Connection = _Connection;
           return Command;
        }
    }
    public Dictionary<string, object> ExecuteRow(string sql, OleDbParameter[] dbParameter)
    {
        OleDbDataReader DataReader = ExecuteReader(sql, dbParameter);
        if (DataReader!=null)
        {
            if (DataReader.Read())
            {
                Dictionary<string, object> Dictionary = new Dictionary<string, object>();
                for (int i = 0; i < DataReader.FieldCount; i++)
                {
                    Dictionary.Add(DataReader.GetName(i),DataReader.GetValue(i)); 
                }
                return Dictionary;
            }
           
        }
        return null;
    }
    public Dictionary<string, object> ExecuteRow(string sql)
    {
        return ExecuteRow(sql,null);
    }
    public ArrayList ExecuteColumns(string sql, OleDbParameter[] dbParameter, int Column)
    {
        OleDbDataReader DataReader = ExecuteReader(sql, dbParameter);
        if (DataReader != null)
        {
            ArrayList List = new ArrayList();
            while (DataReader.Read())
            {
                List.Add(DataReader.GetValue(Column));
            }
            DataReader.Close();
            return List;
        }
        return null;
    }
    public ArrayList ExecuteColumns(string sql, OleDbParameter[] dbParameter)
    {
        return ExecuteColumns(sql, dbParameter, 0);
    }
    public ArrayList ExecuteColumns(string sql, int Column)
    {
        return ExecuteColumns(sql,null, Column);
    }
    public ArrayList ExecuteColumns(string sql)
    {
        return ExecuteColumns(sql, null, 0);
    }
}
