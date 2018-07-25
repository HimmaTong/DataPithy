﻿using Ivony.Data.Common;
using Ivony.Data.Queries;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivony.Data
{

  /// <summary>
  /// 提供一系列静态方法辅助访问数据库
  /// </summary>
  public static class Db
  {



    /// <summary>
    /// 解析模板表达式，创建参数化查询对象
    /// </summary>
    /// <param name="template">参数化模板</param>
    /// <returns>参数化查询</returns>
    public static ParameterizedQuery Template( FormattableString template )
    {
      return TemplateParser.ParseTemplate( template );
    }




    /// <summary>
    /// 解析模板表达式，创建参数化查询对象
    /// </summary>
    /// <param name="template">参数化模板</param>
    /// <returns>参数化查询</returns>
    public static ParameterizedQuery T( FormattableString template )
    {
      return Template( template );
    }



    /// <summary>
    /// 允许非 object[] 类型的数组对象作为多参数列表使用，即允许任意类型数组展开成参数列表。
    /// </summary>
    public static bool AllowNonObjectArrayAsArgs { get; set; }


    private static IDbProvider GetDbProvider( string name )
    {
      return null;
    }



    /// <summary>
    /// 将多个参数化查询串联起来并用指定的字符串分隔
    /// </summary>
    /// <param name="sperator">分隔符</param>
    /// <param name="queries">参数化查询</param>
    /// <returns>串联后的结果</returns>
    public static ParameterizedQuery Join( this string sperator, params ParameterizedQuery[] queries )
    {

      if ( queries == null )
        throw new ArgumentNullException( "queries" );


      queries = queries.Where( i => i != null ).ToArray();//去除所有为 null 的参数化查询对象
      if ( !queries.Any() )
        return null;

      var builder = new ParameterizedQueryBuilder();
      queries[0].AppendTo( builder );

      foreach ( var q in queries.Skip( 1 ) )
      {
        if ( !builder.IsEndWithWhiteSpace() && !char.IsWhiteSpace( sperator[0] ) && Db.AddWhiteSpaceOnConcat )
          builder.Append( ' ' );

        builder.AppendText( sperator );

        if ( !builder.IsEndWithWhiteSpace() && !q.IsStartWithWhiteSpace() && Db.AddWhiteSpaceOnConcat )
          builder.Append( ' ' );

        builder.AppendPartial( q );
      }


      return builder.CreateQuery();
    }



    static Db()
    {
      AddWhiteSpaceOnConcat = true;
    }


    /// <summary>
    /// 获取或设置当串联两个参数化查询时，是否应当自动插入空白字符。
    /// </summary>
    internal static bool AddWhiteSpaceOnConcat
    {
      get;
      set;
    }

  }
}
