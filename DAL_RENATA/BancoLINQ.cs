using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using System.Data.Linq;
using System.Collections.Generic;

namespace REGRA_RENATA
{
    /// <summary>
    /// Realiza a Ponte entre o LINQ - Banco por meio do DataContext
    /// </summary>
    public class BancoLINQ<T> where T : DataContext, new()
    {
        /// <summary>
        /// Data Context
        /// </summary>
        public T DataContext { get; set; }

        public BancoLINQ()
        {
            if (this.DataContext == null)
            {
                this.DataContext = new T();

                try
                {
                    //Com Pool

                    //S4W
                    this.DataContext.Connection.ConnectionString = "Data Source=NEBULUS_PC\\SQLEXPRESS;Initial Catalog=renatadb;Integrated Security=True";
                    this.DataContext.Connection.Open();

                    //LOCAWEB
                    //this.DataContext.Connection.ConnectionString = "Data Source=186.202.148.131;Initial Catalog=accesso2;User ID=accesso2;Password=acc2468;Pooling=true;Min Pool Size=3;Max Pool Size=60;Connect Timeout=3";
                    //this.DataContext.Connection.Open();
                }
                catch (Exception)
                {
                    //Sem Pool

                    //S4W
                    this.DataContext.Connection.ConnectionString = "Data Source=S4W-SERVER;Initial Catalog=S4W_Treinamento_Accesso;User ID=s4wtreinoaccesso;Password=treino123;Pooling=false";
                    this.DataContext.Connection.Open();

                    //LOCAWEB
                    //this.DataContext.Connection.ConnectionString = "Data Source=186.202.148.131;Initial Catalog=accesso2;User ID=accesso2;Password=acc2468;Pooling=false";
                    //this.DataContext.Connection.Open();
                }
            }
        }

        /// <summary>
        /// Inicia uma Transação no Banco de Dados.
        /// </summary>
        /// <param name="isolationLevel">Nível de Isolamento</param>
        /// <returns></returns>
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

        /// <summary>
        /// Inicia uma Transação no Banco de Dados. Nível padrão: ReadCommited
        /// </summary>
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

        /// <summary>
        /// Comita uma Transação corrente no Banco de Dados
        /// </summary>
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

        /// <summary>
        /// Rollback em uma Transação corrente no Banco de Dados
        /// </summary>
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