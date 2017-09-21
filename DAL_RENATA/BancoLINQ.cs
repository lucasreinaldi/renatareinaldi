using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using System.Data.Linq;
using System.Collections.Generic;

namespace REGRA_RENATA
{
    
    public class BancoLINQ<T> where T : DataContext, new()
    {
        
        public T DataContext { get; set; }

        public BancoLINQ()
        {
            if (this.DataContext == null)
            {
                this.DataContext = new T();

                try
                {
                   

                 
                    this.DataContext.Connection.ConnectionString = "Data Source=NEBULUS_PC\\SQLEXPRESS;Initial Catalog=renatadb;Integrated Security=True";
                    this.DataContext.Connection.Open();

                   
                }
                catch (Exception)
                {
                   
                    

                
                }
            }
        }

      
        public bool BeginTransaction(IsolationLevel isolationLevel)
        {
            try
            {
                this.DataContext.Transaction = this.DataContext.Connection.BeginTransaction(isolationLevel);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

      
        public void BeginTransaction()
        {
            try
            {
                this.DataContext.Transaction = this.DataContext.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    
        public void CommitTransaction()
        {
            try
            {
                this.DataContext.Transaction.Commit();
            }
            catch (Exception ex)
            {
                if (this.DataContext.Transaction != null)
                    this.DataContext.Transaction.Rollback();

                throw ex;
            }
            finally
            {
                if (this.DataContext.Connection.State == ConnectionState.Open)
                    this.DataContext.Connection.Close();
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                this.DataContext.Transaction.Rollback();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (this.DataContext.Connection.State == ConnectionState.Open)
                    this.DataContext.Connection.Close();
            }
        }
    }
}