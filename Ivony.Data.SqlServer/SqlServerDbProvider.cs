﻿using Ivony.Data.Common;
using Ivony.Data.Queries;
using Ivony.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ivony.Data
{

  /// <summary>
  /// SqlServer 数据库提供程序
  /// </summary>
  public class SqlServerDbProvider : IDbProvider
  {
    /// <summary>
    /// 创建 SqlServerDbProvider 对象
    /// </summary>
    /// <param name="connectionString">SQL Server 连接字符串</param>
    public SqlServerDbProvider( string connectionString )
    {
      ConnectionString = connectionString ?? throw new ArgumentNullException( nameof( connectionString ) );
    }

    /// <summary>
    /// 连接字符串
    /// </summary>
    public string ConnectionString { get; private set; }


    /// <summary>
    /// 获取 SQL Server 查询执行器
    /// </summary>
    /// <param name="context">当前数据库上下文</param>
    /// <returns></returns>
    public IDbExecutor GetDbExecutor( DbContext context )
    {
      return new SqlDbExecutor( ConnectionString );
    }

    /// <summary>
    /// 创建数据库事务
    /// </summary>
    /// <param name="context">当前数据库上下文</param>
    /// <returns></returns>
    public IDbTransactionContext CreateTransaction( DbContext context )
    {
      return new SqlServerTransactionContext( context, ConnectionString );
    }
  }
}
