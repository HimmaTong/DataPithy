﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Ivony.Data.Queries;
using System.Text.RegularExpressions;
using Ivony.Data.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Ivony.Data
{

  /// <summary>
  /// 有关模板的扩展方法
  /// </summary>
  public static class TemplateExtensions
  {

    /// <summary>
    /// 根据模板表达式创建参数化查询实例
    /// </summary>
    /// <param name="executor">查询执行器</param>
    /// <param name="template">参数化模板</param>
    /// <returns>参数化查询实例</returns>
    public static DbExecutableQuery<ParameterizedQuery> Template( this IDbExecutor<ParameterizedQuery> executor, FormattableString template )
    {
      return new DbExecutableQuery<ParameterizedQuery>( executor, executor.Environment.Template( template ) );
    }


    /// <summary>
    /// 创建指定参数化查询的可执行实例
    /// </summary>
    /// <param name="executor">查询执行器</param>
    /// <param name="query">参数化查询实例</param>
    /// <returns>参数化查询实例</returns>
    public static DbExecutableQuery<ParameterizedQuery> Template( this IDbExecutor<ParameterizedQuery> executor, ParameterizedQuery query )
    {
      return new DbExecutableQuery<ParameterizedQuery>( executor, query );
    }


    /// <summary>
    /// 根据模板表达式创建参数化查询实例
    /// </summary>
    /// <param name="executor">查询执行器</param>
    /// <param name="template">参数化模板</param>
    /// <returns>参数化查询实例</returns>
    public static AsyncDbExecutableQuery<ParameterizedQuery> Template( this IAsyncDbExecutor<ParameterizedQuery> executor, FormattableString template )
    {
      return new AsyncDbExecutableQuery<ParameterizedQuery>( executor, executor.Environment.Template( template ) );
    }


    /// <summary>
    /// 创建指定参数化查询的可执行实例
    /// </summary>
    /// <param name="executor">查询执行器</param>
    /// <param name="query">参数化查询实例</param>
    /// <returns>参数化查询实例</returns>
    public static AsyncDbExecutableQuery<ParameterizedQuery> Template( this IAsyncDbExecutor<ParameterizedQuery> executor, ParameterizedQuery query )
    {
      return new AsyncDbExecutableQuery<ParameterizedQuery>( executor, query );
    }







    /// <summary>
    /// 根据模板表达式创建参数化查询实例
    /// </summary>
    /// <param name="executor">查询执行器</param>
    /// <param name="template">参数化模板</param>
    /// <returns>参数化查询实例</returns>
    public static DbExecutableQuery<ParameterizedQuery> T( this IDbExecutor<ParameterizedQuery> executor, FormattableString template )
    {
      return new DbExecutableQuery<ParameterizedQuery>( executor, executor.Environment.Template( template ) );
    }



    /// <summary>
    /// 创建指定参数化查询的可执行实例
    /// </summary>
    /// <param name="executor">查询执行器</param>
    /// <param name="query">参数化查询实例</param>
    /// <returns>参数化查询实例</returns>
    public static DbExecutableQuery<ParameterizedQuery> T( this IDbExecutor<ParameterizedQuery> executor, ParameterizedQuery query )
    {
      return new DbExecutableQuery<ParameterizedQuery>( executor, query );
    }


    /// <summary>
    /// 根据模板表达式创建参数化查询实例
    /// </summary>
    /// <param name="executor">查询执行器</param>
    /// <param name="template">参数化模板</param>
    /// <returns>参数化查询实例</returns>
    public static AsyncDbExecutableQuery<ParameterizedQuery> T( this IAsyncDbExecutor<ParameterizedQuery> executor, FormattableString template )
    {
      return Template( executor, template );
    }


    /// <summary>
    /// 创建指定参数化查询的可执行实例
    /// </summary>
    /// <param name="executor">查询执行器</param>
    /// <param name="query">参数化查询实例</param>
    /// <returns>参数化查询实例</returns>
    public static AsyncDbExecutableQuery<ParameterizedQuery> T( this IAsyncDbExecutor<ParameterizedQuery> executor, ParameterizedQuery query )
    {
      return new AsyncDbExecutableQuery<ParameterizedQuery>( executor, query );
    }






    /// <summary>
    /// 根据模板表达式创建参数化查询实例
    /// </summary>
    /// <param name="transaction">数据库事务对象</param>
    /// <param name="template">参数化模板</param>
    /// <returns>参数化查询实例</returns>
    public static DbExecutableQuery<ParameterizedQuery> Template( this IDbTransactionContext<IDbExecutor<ParameterizedQuery>> transaction, FormattableString template )
    {
      return transaction.DbExecutor.Template( template );
    }


    /// <summary>
    /// 创建指定参数化查询的可执行实例
    /// </summary>
    /// <param name="transaction">数据库事务对象</param>
    /// <param name="query">参数化查询实例</param>
    /// <returns>参数化查询实例</returns>
    public static DbExecutableQuery<ParameterizedQuery> Template( this IDbTransactionContext<IDbExecutor<ParameterizedQuery>> transaction, ParameterizedQuery query )
    {
      return transaction.DbExecutor.Template( query );
    }


    /// <summary>
    /// 根据模板表达式创建参数化查询实例
    /// </summary>
    /// <param name="transaction">数据库事务对象</param>
    /// <param name="template">参数化模板</param>
    /// <returns>参数化查询实例</returns>
    public static AsyncDbExecutableQuery<ParameterizedQuery> Template( this IDbTransactionContext<IAsyncDbExecutor<ParameterizedQuery>> transaction, FormattableString template )
    {
      return transaction.DbExecutor.Template( template );
    }


    /// <summary>
    /// 创建指定参数化查询的可执行实例
    /// </summary>
    /// <param name="transaction">数据库事务对象</param>
    /// <param name="query">参数化查询实例</param>
    /// <returns>参数化查询实例</returns>
    public static AsyncDbExecutableQuery<ParameterizedQuery> Template( this IDbTransactionContext<IAsyncDbExecutor<ParameterizedQuery>> transaction, ParameterizedQuery query )
    {
      return transaction.DbExecutor.Template( query );
    }


    /// <summary>
    /// 根据模板表达式创建参数化查询实例
    /// </summary>
    /// <param name="transaction">数据库事务对象</param>
    /// <param name="template">参数化模板</param>
    /// <returns>参数化查询实例</returns>
    public static DbExecutableQuery<ParameterizedQuery> T( this IDbTransactionContext<IDbExecutor<ParameterizedQuery>> transaction, FormattableString template )
    {
      return transaction.DbExecutor.Template( template );
    }


    /// <summary>
    /// 创建指定参数化查询的可执行实例
    /// </summary>
    /// <param name="transaction">数据库事务对象</param>
    /// <param name="query">参数化查询实例</param>
    /// <returns>参数化查询实例</returns>
    public static DbExecutableQuery<ParameterizedQuery> T( this IDbTransactionContext<IDbExecutor<ParameterizedQuery>> transaction, ParameterizedQuery query )
    {
      return transaction.DbExecutor.Template( query );
    }


    /// <summary>
    /// 根据模板表达式创建参数化查询实例
    /// </summary>
    /// <param name="transaction">数据库事务对象</param>
    /// <param name="template">参数化模板</param>
    /// <returns>参数化查询实例</returns>
    public static AsyncDbExecutableQuery<ParameterizedQuery> T( this IDbTransactionContext<IAsyncDbExecutor<ParameterizedQuery>> transaction, FormattableString template )
    {
      return transaction.DbExecutor.Template( template );
    }


    /// <summary>
    /// 创建指定参数化查询的可执行实例
    /// </summary>
    /// <param name="transaction">数据库事务对象</param>
    /// <param name="query">参数化查询实例</param>
    /// <returns>参数化查询实例</returns>
    public static AsyncDbExecutableQuery<ParameterizedQuery> T( this IDbTransactionContext<IAsyncDbExecutor<ParameterizedQuery>> transaction, ParameterizedQuery query )
    {
      return transaction.DbExecutor.Template( query );
    }




    /// <summary>
    /// 串联两个参数化查询对象
    /// </summary>
    /// <param name="firstQuery">第一个参数化查询对象</param>
    /// <param name="secondQuery">第二个参数化查询对象</param>
    /// <returns>串联后的参数化查询对象</returns>
    public static ParameterizedQuery Concat( this ParameterizedQuery firstQuery, ParameterizedQuery secondQuery )
    {
      return ConcatQueries( firstQuery, secondQuery );
    }

    /// <summary>
    /// 串联多个参数化查询对象
    /// </summary>
    /// <param name="firstQuery">第一个参数化查询对象</param>
    /// <param name="otherQueries">要串联的其他参数化查询对象</param>
    /// <returns>串联后的参数化查询对象</returns>
    public static ParameterizedQuery ConcatQueries( this ParameterizedQuery firstQuery, params ParameterizedQuery[] otherQueries )
    {
      var builder = firstQuery.Services.GetService<IParameterizedQueryBuilder>();

      firstQuery.AppendTo( builder );
      foreach ( var query in otherQueries )
      {
        if ( query == null || string.IsNullOrEmpty( query.TextTemplate ) )
          continue;

        query.AppendTo( builder );
      }

      return builder.BuildQuery();
    }



    /// <summary>
    /// 串联两个参数化查询对象
    /// </summary>
    /// <param name="firstQuery">第一个参数化查询对象</param>
    /// <param name="secondQuery">第二个参数化查询对象</param>
    /// <returns>串联后的参数化查询对象</returns>
    public static DbExecutableQuery<ParameterizedQuery> Concat( this DbExecutableQuery<ParameterizedQuery> firstQuery, ParameterizedQuery secondQuery )
    {
      return ConcatQueries( firstQuery, secondQuery );
    }


    /// <summary>
    /// 串联两个参数化查询对象
    /// </summary>
    /// <param name="firstQuery">第一个参数化查询对象</param>
    /// <param name="secondQuery">第二个参数化查询对象</param>
    /// <returns>串联后的参数化查询对象</returns>
    public static AsyncDbExecutableQuery<ParameterizedQuery> Concat( this AsyncDbExecutableQuery<ParameterizedQuery> firstQuery, ParameterizedQuery secondQuery )
    {
      return ConcatQueries( firstQuery, secondQuery );
    }


    /// <summary>
    /// 串联多个参数化查询对象
    /// </summary>
    /// <param name="firstQuery">第一个参数化查询对象</param>
    /// <param name="otherQueries">要串联的其他参数化查询对象</param>
    /// <returns>串联后的参数化查询对象</returns>
    public static DbExecutableQuery<ParameterizedQuery> ConcatQueries( this DbExecutableQuery<ParameterizedQuery> firstQuery, params ParameterizedQuery[] otherQueries )
    {
      var query = ConcatQueries( firstQuery.Query, otherQueries );
      return new DbExecutableQuery<ParameterizedQuery>( firstQuery.Executor, query );
    }


    /// <summary>
    /// 串联多个参数化查询对象
    /// </summary>
    /// <param name="firstQuery">第一个参数化查询对象</param>
    /// <param name="otherQueries">要串联的其他参数化查询对象</param>
    /// <returns>串联后的参数化查询对象</returns>
    public static AsyncDbExecutableQuery<ParameterizedQuery> ConcatQueries( this AsyncDbExecutableQuery<ParameterizedQuery> firstQuery, params ParameterizedQuery[] otherQueries )
    {
      var query = ConcatQueries( firstQuery.Query, otherQueries );
      return new AsyncDbExecutableQuery<ParameterizedQuery>( firstQuery.Executor, query );
    }




    /// <summary>
    /// 通过模板产生一个参数化查询对象并串联到现有的参数化查询对象之后
    /// </summary>
    /// <param name="firstQuery">需要被串联的参数化查询对象</param>
    /// <param name="templateText">SQL 命令模版</param>
    /// <param name="parameters">模版参数列表</param>
    /// <returns>串联后的参数化查询对象</returns>
    public static DbExecutableQuery<ParameterizedQuery> Concat( this DbExecutableQuery<ParameterizedQuery> firstQuery, FormattableString template )
    {
      return Concat( firstQuery, firstQuery.Executor.Environment.T( template ) );
    }


    /// <summary>
    /// 通过模板产生一个参数化查询对象并串联到现有的参数化查询对象之后
    /// </summary>
    /// <param name="firstQuery">需要被串联的参数化查询对象</param>
    /// <param name="templateText">SQL 命令模版</param>
    /// <param name="parameters">模版参数列表</param>
    /// <returns>串联后的参数化查询对象</returns>
    public static AsyncDbExecutableQuery<ParameterizedQuery> Concat( this AsyncDbExecutableQuery<ParameterizedQuery> firstQuery, FormattableString template )
    {
      return Concat( firstQuery, firstQuery.Executor.Environment.T( template ) );
    }

  }
}
