using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace ICONHRPortal
{
    public static class json2Table
    {
        #region Json to DataTable
        public static DataTable JsonStringToDataTable(string jsonString)
        {
            DataTable dt = new DataTable();
            string[] jsonStringArray = Regex.Split(jsonString.Replace("[", "").Replace("]", ""), "},{");
            List<string> ColumnsName = new List<string>();
            foreach (string jSA in jsonStringArray)
            {
                string[] jsonStringData = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",");
                foreach (string ColumnsNameData in jsonStringData)
                {
                    try
                    {
                        int idx = ColumnsNameData.IndexOf(":");
                        string ColumnsNameString = ColumnsNameData.Substring(0, idx - 1).Replace("\"", "");
                        if (!ColumnsName.Contains(ColumnsNameString))
                        {
                            ColumnsName.Add(ColumnsNameString);
                        }
                    }
                    catch (Exception)
                    {
                        throw new Exception(string.Format("Error Parsing Column Name : {0}", ColumnsNameData));
                    }
                }
                break;
            }
            foreach (string AddColumnName in ColumnsName)
            {
                dt.Columns.Add(AddColumnName);
            }
            foreach (string jSA in jsonStringArray)
            {
                string[] RowData = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",");
                DataRow nr = dt.NewRow();
                foreach (string rowData in RowData)
                {
                    try
                    {
                        int idx = rowData.IndexOf(":");
                        string RowColumns = rowData.Substring(0, idx - 1).Replace("\"", "");
                        string RowDataString = rowData.Substring(idx + 1).Replace("\"", "");
                        nr[RowColumns] = RowDataString;
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                dt.Rows.Add(nr);
            }
            return dt;
        }


        public static string FromDictionaryToJson(this Dictionary<string, string> dictionary)
        {
            var kvs = dictionary.Select(kvp => string.Format("\"{0}\":\"{1}\"", kvp.Key, string.Join(",", kvp.Value)));
            return string.Concat("{", string.Join(",", kvs), "}");
        }

        public static Dictionary<string, string> FromJsonToDictionary(this string json)
        {
            string[] keyValueArray = json.Replace("{", string.Empty).Replace("}", string.Empty).Replace("\"", string.Empty).Split(',');
            return keyValueArray.ToDictionary(item => item.Split(':')[0], item => item.Split(':')[1]);
        }

        public static DataTable GetDataTableFromDictionaries<T>(List<Dictionary<string, T>> list)
        {
            DataTable dataTable = new DataTable();

            if (list == null || !list.Any()) return dataTable;

            foreach (var column in list.First().Select(c => new DataColumn(c.Key, typeof(T))))
            {
                dataTable.Columns.Add(column);
            }

            foreach (var row in list.Select(
                r =>
                {
                    var dataRow = dataTable.NewRow();
                    r.ToList().ForEach(c => dataRow.SetField(c.Key, c.Value));
                    return dataRow;
                }))
            {
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        public static DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            // column names
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }
                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue(rec, null);
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }
        #endregion

        #region Export to Excel
        public static void ExporttoExcel1(DataTable table, string filename)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            //HttpContext.Current.Response.ContentType = "application/ms-word";
            HttpContext.Current.Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + filename + ".xls");
            // HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=Reports.doc");
            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
            HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
            HttpContext.Current.Response.Write("<BR><BR><BR>");
            HttpContext.Current.Response.Write("<Table border='1' bgColor='#ffffff' borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; background:white;'> <TR>");
            int columnscount = table.Columns.Count;

            for (int j = 0; j < columnscount; j++)
            {
                HttpContext.Current.Response.Write("<Td>");
                HttpContext.Current.Response.Write("<B>");
                HttpContext.Current.Response.Write(table.Columns[j].ColumnName.ToString());
                HttpContext.Current.Response.Write("</B>");
                HttpContext.Current.Response.Write("</Td>");
            }
            HttpContext.Current.Response.Write("</TR>");
            foreach (DataRow row in table.Rows)
            {
                HttpContext.Current.Response.Write("<TR>");
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    HttpContext.Current.Response.Write("<Td>");
                    HttpContext.Current.Response.Write(row[i].ToString());
                    HttpContext.Current.Response.Write("</Td>");
                }

                HttpContext.Current.Response.Write("</TR>");
            }
            HttpContext.Current.Response.Write("</Table>");
            HttpContext.Current.Response.Write("</font>");
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

        public static void ExporttoExcel2(string html, string filename)
        {
            HttpContext.Current.Response.ContentType = "application/force-download";
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + filename + ".xls");
            HttpContext.Current.Response.Write("<html xmlns:x=\"urn:schemas-microsoft-com:office:excel\">");
            HttpContext.Current.Response.Write("<head>");
            HttpContext.Current.Response.Write("<META http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
            HttpContext.Current.Response.Write("<!--[if gte mso 9]><xml>");
            HttpContext.Current.Response.Write("<x:ExcelWorkbook>");
            HttpContext.Current.Response.Write("<x:ExcelWorksheets>");
            HttpContext.Current.Response.Write("<x:ExcelWorksheet>");
            HttpContext.Current.Response.Write("<x:Name>Report Data</x:Name>");
            HttpContext.Current.Response.Write("<x:WorksheetOptions>");
            HttpContext.Current.Response.Write("<x:Selected/> ");
            HttpContext.Current.Response.Write("<x:DoNotDisplayGridlines />");
             HttpContext.Current.Response.Write("<x:FitWidth>1</x:FitWidth>");
            HttpContext.Current.Response.Write("<x:Print>");
            HttpContext.Current.Response.Write("<x:ValidPrinterInfo/>");
            HttpContext.Current.Response.Write("</x:Print>");
            HttpContext.Current.Response.Write("</x:WorksheetOptions>");
            HttpContext.Current.Response.Write("</x:ExcelWorksheet>");
            HttpContext.Current.Response.Write("</x:ExcelWorksheets>");
            HttpContext.Current.Response.Write("</x:ExcelWorkbook>");
            HttpContext.Current.Response.Write("</xml>");
            HttpContext.Current.Response.Write("<![endif]--> ");
            HttpContext.Current.Response.Write(html); // give ur html string here
            HttpContext.Current.Response.Write("</head>");
            HttpContext.Current.Response.Flush();

        }
        #endregion

        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        public static DataTable ConvertToDataTable<TSource>(this IEnumerable<TSource>
                    records, params Expression<Func<TSource, object>>[] columns)
        {
            var firstRecord = records.First();
            if (firstRecord == null)
                return null;

            DataTable table = new DataTable();

            List<Func<TSource, object>> functions = new List<Func<TSource, object>>();
            foreach (var col in columns)
            {
                DataColumn column = new DataColumn();
                column.Caption = (col.Body as MemberExpression).Member.Name;
                var function = col.Compile();
                column.DataType = function(firstRecord).GetType();
                functions.Add(function);
                table.Columns.Add(column);
            }

            foreach (var record in records)
            {
                DataRow row = table.NewRow();
                int i = 0;
                foreach (var function in functions)
                {
                    row[i] = function((record));
                }
                table.Rows.Add(row[i]);
            }
            return table;
        }

        public static DataTable MergeAll(this IList<DataTable> tables, String primaryKeyColumn)
        {
            if (!tables.Any())
                throw new ArgumentException("Tables must not be empty", "tables");
            if (primaryKeyColumn != null)
                foreach (DataTable t in tables)
                    if (!t.Columns.Contains(primaryKeyColumn))
                        throw new ArgumentException("All tables must have the specified primarykey column " + primaryKeyColumn, "primaryKeyColumn");

            if (tables.Count == 1)
                return tables[0];

            DataTable table = new DataTable("TblUnion");
            table.BeginLoadData(); // Turns off notifications, index maintenance, and constraints while loading data
            foreach (DataTable t in tables)
            {
                table.Merge(t); // same as table.Merge(t, false, MissingSchemaAction.Add);
            }
            table.EndLoadData();

            if (primaryKeyColumn != null)
            {
                // since we might have no real primary keys defined, the rows now might have repeating fields
                // so now we're going to "join" these rows ...
                var pkGroups = table.AsEnumerable()
                    .GroupBy(r => r[primaryKeyColumn]);
                var dupGroups = pkGroups.Where(g => g.Count() > 1);
                foreach (var grpDup in dupGroups)
                {
                    // use first row and modify it
                    DataRow firstRow = grpDup.First();
                    foreach (DataColumn c in table.Columns)
                    {
                        if (firstRow.IsNull(c))
                        {
                            DataRow firstNotNullRow = grpDup.Skip(1).FirstOrDefault(r => !r.IsNull(c));
                            if (firstNotNullRow != null)
                                firstRow[c] = firstNotNullRow[c];
                        }
                    }
                    // remove all but first row
                    var rowsToRemove = grpDup.Skip(1);
                    foreach (DataRow rowToRemove in rowsToRemove)
                        table.Rows.Remove(rowToRemove);
                }
            }

            return table;
        }

        public static void Convert1<T>(this DataColumn column, Func<object, T> conversion)
        {
            foreach (DataRow row in column.Table.Rows)
            {
                row[column] = conversion(row[column]);
            }
        }

        public static IEnumerable<Tuple<string, int>> MonthsBetween(
                DateTime startDate,
                DateTime endDate)
        {
            DateTime iterator;
            DateTime limit;

            if (endDate > startDate)
            {
                iterator = new DateTime(startDate.Year, startDate.Month, 1);
                limit = endDate;
            }
            else
            {
                iterator = new DateTime(endDate.Year, endDate.Month, 1);
                limit = startDate;
            }

            var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
            while (iterator <= limit)
            {
                yield return Tuple.Create(
                    dateTimeFormat.GetMonthName(iterator.Month),
                    iterator.Year);
                iterator = iterator.AddMonths(1);
            }
        }

        public static string ConvertDataTableToHTML(DataTable dt)
        {
            string html = "<table>";
            //add header row
            html += "<tr>";
            for (int i = 0; i < dt.Columns.Count; i++)
                html += "<td>" + dt.Columns[i].ColumnName + "</td>";
            html += "</tr>";
            //add rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "<tr>";
                for (int j = 0; j < dt.Columns.Count; j++)
                    html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            return html;
        }

        public static string GetApiToken()
        {
            #region CreditCard Authentication
            string UserName = string.Empty;
            string APIpassword = string.Empty;
            string authToken = string.Empty;
            string authAPI = string.Empty;
            string apiDomain = string.Empty;
            string ResultAPIKey = string.Empty;


            authAPI = System.Configuration.ConfigurationManager.AppSettings["authAPI"];
            UserName = System.Configuration.ConfigurationManager.AppSettings["Username"];
            APIpassword = System.Configuration.ConfigurationManager.AppSettings["Password"];
            apiDomain = System.Configuration.ConfigurationManager.AppSettings["apidomain"];
            authToken = System.Configuration.ConfigurationManager.AppSettings["Token"];
            string authAddr = apiDomain + authAPI;
            var authWebRequest = (HttpWebRequest)WebRequest.Create(authAddr);
            authWebRequest.ContentType = "application/json; charset=utf-8";
            authWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(authWebRequest.GetRequestStream()))
            {
                string json = "{\"Username\": \"" + UserName + "\"," +
                               "\"Password\" : \"" + APIpassword + "\"," +
                               "\"Token\" : \"" + authToken + "\"}";
                streamWriter.Write(json);
                streamWriter.Flush();
            }

            var httpResponse = (HttpWebResponse)authWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                string responseData = result;
                string tokenToGetQuoteInfo = string.Empty;
                if (!string.IsNullOrEmpty(responseData))
                {
                    string data = JObject.Parse(responseData)["ApiResponse"].ToString();
                    DataTable dtToken = new DataTable();
                    DataTable dtADUsers = new DataTable();
                    dtToken = ICONHRPortal.json2Table.JsonStringToDataTable(data);
                    dtToken.Columns[0].ColumnName = "ApiKey";
                    dtToken.Columns[1].ColumnName = "SessionExpiry";
                    if (dtToken.Rows.Count > 0)
                    {
                        tokenToGetQuoteInfo = Convert.ToString(dtToken.Rows[0]["ApiKey"]).Trim();
                        if (!string.IsNullOrEmpty(authToken))
                        {
                            ResultAPIKey= Convert.ToString(dtToken.Rows[0]["ApiKey"]).Trim()+","+ Convert.ToString(dtToken.Rows[0]["SessionExpiry"]).Trim();
                        }
                    }
                }
                return ResultAPIKey;
            }
            #endregion
        }

        public static string GetPaymentGatewayApiToken()
        {
            #region CreditCard Authentication
            string UserName = string.Empty;
            string APIpassword = string.Empty;
            string authToken = string.Empty;
            string authAPI = string.Empty;
            string apiDomain = string.Empty;
            string ResultAPIKey = string.Empty;

            authAPI = System.Configuration.ConfigurationManager.AppSettings["PaymentauthAPI"];
            UserName = System.Configuration.ConfigurationManager.AppSettings["PaymentApiUsername"];
            APIpassword = System.Configuration.ConfigurationManager.AppSettings["PaymentApiPassword"];
            apiDomain = System.Configuration.ConfigurationManager.AppSettings["PaymentApiDomain"];
            authToken = System.Configuration.ConfigurationManager.AppSettings["PaymentApiToken"];
            string authAddr = apiDomain + authAPI;
            var authWebRequest = (HttpWebRequest)WebRequest.Create(authAddr);
            authWebRequest.ContentType = "application/json; charset=utf-8";
            authWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(authWebRequest.GetRequestStream()))
            {
                string json = "{\"Username\": \"" + UserName + "\"," +
                               "\"Password\" : \"" + APIpassword + "\"," +
                               "\"Token\" : \"" + authToken + "\"}";
                streamWriter.Write(json);
                streamWriter.Flush();
            }

            var httpResponse = (HttpWebResponse)authWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                string responseData = result;
                string tokenToGetQuoteInfo = string.Empty;
                if (!string.IsNullOrEmpty(responseData))
                {
                    string data = JObject.Parse(responseData)["ApiResponse"].ToString();
                    DataTable dtToken = new DataTable();
                    DataTable dtADUsers = new DataTable();
                    dtToken = ICONHRPortal.json2Table.JsonStringToDataTable(data);
                    dtToken.Columns[0].ColumnName = "ApiKey";
                    dtToken.Columns[1].ColumnName = "SessionExpiry";
                    if (dtToken.Rows.Count > 0)
                    {
                        tokenToGetQuoteInfo = Convert.ToString(dtToken.Rows[0]["ApiKey"]).Trim();
                        if (!string.IsNullOrEmpty(authToken))
                        {
                            ResultAPIKey = Convert.ToString(dtToken.Rows[0]["ApiKey"]).Trim() + "," + Convert.ToString(dtToken.Rows[0]["SessionExpiry"]).Trim();
                        }
                    }
                }
                return ResultAPIKey;
            }
            #endregion
        }
    }
}
