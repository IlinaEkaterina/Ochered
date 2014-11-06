using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WcfServiceLibrary1
{
    
 
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service1 : IService1
    {

        public List<bool> actcash()
        {
            List<bool> sost = new List<bool>();
            DataTable dtmain = new DataTable();
            using (SqlConnection con = OpenConnection())
            {
                string strSQL = "SELECT activity_cash FROM cash";
                SqlDataAdapter ad = new SqlDataAdapter(strSQL, con);
                ad.Fill(dtmain);
            }
            for (int i = 0; i < dtmain.Rows.Count; i++)
            {
                sost.Add(Convert.ToBoolean(dtmain.Rows[i]["activity_cash"].ToString()));
            }
            return sost;
        }

        public int turn_cash(int cash)
        {
            int type =0 ;
            DataTable dtmain = new DataTable();
            using (SqlConnection con = OpenConnection())
            {
                string strSQL = "SELECT * FROM turn_cash WHERE Id_cash="+cash;
                SqlDataAdapter ad = new SqlDataAdapter(strSQL, con);
                ad.Fill(dtmain);
            }
            for (int i = 0; i < dtmain.Rows.Count; i++)
            {
               type = Convert.ToInt32(dtmain.Rows[i]["Id_turn"].ToString());
            }
            string ss = cash.ToString() + type.ToString();
            type = Convert.ToInt32(ss);
            return type;
        }

        public bool actact(int number_cash, int type)
        {
            using (SqlConnection con = OpenConnection())
            {
                string sql = string.Format("UPDATE cash SET activity_cash='True' WHERE number_cash="+number_cash);
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            using (SqlConnection con = OpenConnection())
            {
                string sql = string.Format("INSERT INTO turn_cash (Id_turn, Id_cash) VALUES ("+type+", "+number_cash+")");
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }

        public bool cash_off(int number_cash)
        {
            using (SqlConnection con = OpenConnection())
            {
                string sql = string.Format("UPDATE cash SET activity_cash='False' WHERE number_cash=" + number_cash);
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            using (SqlConnection con = OpenConnection())
            {
                string sql = string.Format("DELETE FROM turn_cash WHERE Id_cash="+number_cash+"");
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public SqlConnection OpenConnection()
        {
            SqlConnection con = new SqlConnection("Data Source=OME;Initial Catalog=prartica_bd;Integrated Security=True");
            con.Open();
            return con;
        }

        public string getidstatus (string idts, string casa, string ds, string ts )
        {
            string idst = "";
            DataTable dtmain = new DataTable();
            using (SqlConnection con = OpenConnection())
            {
                string strSQL = "SELECT Id_status FROM status WHERE Id_type_status="+ idts + " AND Id_cash="+ casa + " AND date_status='"+ ds + "' AND tame_status='"+ ts+"'" ;
                SqlDataAdapter ad = new SqlDataAdapter(strSQL, con);
                ad.Fill(dtmain);
            }
            for (int i = 0; i < dtmain.Rows.Count; i++)
            {
                idst= dtmain.Rows[i]["Id_status"].ToString();
            }
            return idst;
        }

        public List<enrollee> vivod()
        {
            DataTable dtmain = new DataTable();
            using (SqlConnection con = OpenConnection())
            {
                string strSQL = "SELECT * FROM enrollee LEFT JOIN status ON enrollee.status=status.Id_status LEFT JOIN turn ON enrollee.Id_turn=turn.Id_turn LEFT JOIN type_status ON status.Id_type_status=type_status.Id_type_status LEFT JOIN cash ON status.Id_cash=cash.Id_cash";
                SqlDataAdapter ad = new SqlDataAdapter(strSQL, con);
                ad.Fill(dtmain);
            }

            List<enrollee> enrollee = new List<enrollee>();
            for (int i = 0; i < dtmain.Rows.Count; i++)
            {
                enrollee temp = new enrollee();
                temp.surname = dtmain.Rows[i]["surname"].ToString();
                temp.name = dtmain.Rows[i]["name"].ToString();
                temp.patronymic = dtmain.Rows[i]["patronymic"].ToString();
                temp.date_coming = Convert.ToDateTime(dtmain.Rows[i]["date_coming"].ToString()).ToString("d MMMMMM yyyy");
                temp.time_coming = Convert.ToDateTime(dtmain.Rows[i]["time_coming"].ToString()).TimeOfDay.ToString(@"hh\:mm");
                temp.date_call = Convert.ToDateTime(dtmain.Rows[i]["date_call"].ToString()).ToString("d MMMMMM yyyy");
                temp.time_call = Convert.ToDateTime(dtmain.Rows[i]["time_call"].ToString()).TimeOfDay.ToString(@"hh\:mm");
                temp.status = dtmain.Rows[i]["status_name"].ToString();
                temp.turn = dtmain.Rows[i]["Type_turn"].ToString();
                temp.cash = dtmain.Rows[i]["number_cash"].ToString();
                enrollee.Add(temp);
            }
            return enrollee;
        }

        public bool dobav(string surname, string name, string patronymic, string date_coming, string time_coming, string date_call, string time_call, string status, string turn)
        {
            using (SqlConnection con = OpenConnection())
            {
                string sql = string.Format("INSERT INTO enrollee(surname, name, patronymic , date_coming , time_coming , date_call, time_call, status, Id_turn) VALUES ('" + surname + "',  '" + name + "', '" + patronymic + "', '" + date_coming + "', '" + time_coming + "', '" + date_call + "', '" + time_call + "', '" + status + "', '" + turn + "')");
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }

        public bool dobav1(string Id_type_status, string Id_cash, string date_status, string tame_status)
        {
            using (SqlConnection con = OpenConnection())
            {
                string sql = string.Format("INSERT INTO status(Id_type_status, Id_cash, date_status, tame_status) VALUES ('" + Id_type_status + "',  '" + Id_cash + "', '" + date_status + "', '" + tame_status + "')");
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }
        public List<string> vozvr_spis ()
        {
            DataTable dtmain = new DataTable();
            using (SqlConnection con = OpenConnection())
            {
                string strSQL = "SELECT * FROM enrollee LEFT JOIN status ON enrollee.status=status.Id_status LEFT JOIN turn ON enrollee.Id_turn=turn.Id_turn LEFT JOIN type_status ON status.Id_type_status=type_status.Id_type_status LEFT JOIN cash ON status.Id_cash=cash.Id_cash ORDER BY 'time_coming' ASC";
                SqlDataAdapter ad = new SqlDataAdapter(strSQL, con);
                ad.Fill(dtmain);
            }

            List<string> spim = new List<string>();
            for (int i = 0; i < dtmain.Rows.Count; i++)
            {
                enrollee temp = new enrollee();
                temp.surname = dtmain.Rows[i]["surname"].ToString();
                temp.name = dtmain.Rows[i]["name"].ToString();
                temp.patronymic = dtmain.Rows[i]["patronymic"].ToString();
                temp.date_coming = Convert.ToDateTime(dtmain.Rows[i]["date_coming"].ToString()).ToString("d MMMMMM yyyy");
                temp.time_coming = Convert.ToDateTime(dtmain.Rows[i]["time_coming"].ToString()).TimeOfDay.ToString(@"hh\:mm");
                temp.date_call = Convert.ToDateTime(dtmain.Rows[i]["date_call"].ToString()).ToString("d MMMMMM yyyy");
                temp.time_call = Convert.ToDateTime(dtmain.Rows[i]["time_call"].ToString()).TimeOfDay.ToString(@"hh\:mm");
                temp.status = dtmain.Rows[i]["status_name"].ToString();
                temp.turn = dtmain.Rows[i]["Id_turn"].ToString();
                temp.cash = dtmain.Rows[i]["number_cash"].ToString();

                    spim.Add(temp.turn+temp.surname + " " + temp.name.Substring(0, 1) + ". " + temp.patronymic.Substring(0, 1) + ". " );
             }
            return spim;
        }
    }
}
