using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HungryPizzaria.SDK.Extensions
{
    public static class Utils
    {
        public static string MessageResultApplication(this IEnumerable<Object> list)
        {
            StringBuilder sb = new StringBuilder();
            try
            {   
                sb.Append("");

                if (list != null)
                {
                    if (list.Any())
                        sb.AppendLine("Consulta realizada com sucesso!");
                    else
                        sb.AppendLine("Nenhum registro encontrado!");
                }
                else
                {
                    sb.AppendLine("Nenhum registro encontrado!");
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                sb.Append("Erro extensions MessageResultApplication: " );
                sb.AppendLine(ex.Message);

                return sb.ToString();
            }
            finally
            {
                sb.Clear();
                sb = null;
            }

        }

        public static string MessageResultApplication(this object list)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append("");

                if (list != null)
                {
                    sb.AppendLine("Consulta realizada com sucesso!");
                }
                else
                {
                    sb.AppendLine("Nenhum registro encontrado!");
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                sb.Append("Erro extensions MessageResultApplication: ");
                sb.AppendLine(ex.Message);

                return sb.ToString();
            }
            finally
            {
                sb.Clear();
                sb = null;
            }

        }

        public static string ConvertToJson(this object list)
        {
            var sb = JsonConvert.SerializeObject(list);
            return sb.ToString();
        }
    }
}
