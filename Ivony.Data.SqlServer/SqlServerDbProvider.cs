﻿using Ivony.Data.Common;
using Ivony.Data.Queries;
using Ivony.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ivony.Data
{
  public class SqlServerDbProvider : IDbProvider
  {
    public SqlServerDbProvider( string connectionString )
    {
      ConnectionString = connectionString ?? throw new ArgumentNullException( nameof( connectionString ) );
    }

    public string ConnectionString { get; private set; }


    public IDbExecutor GetDbExecutor( DatabaseContext context )
    {
      return new SqlDbExecutor( ConnectionString );
    }

    public IDbTransactionContext CreateTransaction( DatabaseContext context )
    {
      return new SqlServerTransactionContext( ConnectionString );
    }


    public IServiceProvider DbServiceProvider { get; } = new BlankServiceProvider();


  }
}
