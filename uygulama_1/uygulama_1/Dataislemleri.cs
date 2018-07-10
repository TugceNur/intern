using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace uygulama_1
{
    public class dataislemleri

    {
        private static string baglanticumlesi = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=rehber;Integrated Security=True;";
        public SqlConnection _sqlconnection;
        public SqlCommand _sqlcommand;
        public dataislemleri()

        {
            _sqlconnection = new SqlConnection(baglanticumlesi);

            _sqlcommand = new SqlCommand();
            _sqlcommand.CommandTimeout = 0;
        }
        public void Baglanti_Ac()

        {
            if (_sqlconnection.State == ConnectionState.Closed)

            {
                _sqlconnection.Open();
            }
        }
        public void Baglanti_Kapat()

        {
            if (_sqlconnection.State == ConnectionState.Open)

            {
                _sqlconnection.Close();
            }

        }

        //sorgu alıp geriye dataset döndürür

        public DataSet GetDataSetQuery(string query)

        {
            using (SqlDataAdapter _sqldataadapter = new SqlDataAdapter(query, _sqlconnection))

            {
                _sqldataadapter.SelectCommand.CommandTimeout = 0;

                using (DataSet ds = new DataSet())

                {
                    try

                    {

                        Baglanti_Ac();

                        ds.Locale = CultureInfo.InvariantCulture;

                        _sqldataadapter.Fill(ds);

                        return ds;
                    }

                    catch (SqlException ex)

                    {

                        throw new ApplicationException(ex.Message);

                    }

                    finally

                    {
                        Baglanti_Kapat();
                    }
                }
            }
        }
        //sorgu alıp geriye tek bir deger dondurur

        public object GetScalarQuery(string query)

        {
            _sqlcommand.Connection = _sqlconnection;

            _sqlcommand.CommandText = query;

            _sqlcommand.CommandTimeout = 0;

            try

            {
                Baglanti_Ac();
                return _sqlcommand.ExecuteScalar();
            }

            catch (SqlException ex)

            {
                throw new ApplicationException(ex.Message);
            }
            finally

            {
                Baglanti_Kapat();
            }
        }



        // parametreli olan sorguları çalıştırmak için kullanıyoruz.
        public DataSet GetDataSetQueryParameter(string query, SqlParameter[] sqlParams)
        {

            using (SqlDataAdapter _sqldataadapter = new SqlDataAdapter(query, _sqlconnection))
            {
                _sqldataadapter.SelectCommand.CommandTimeout = 0;

                using (DataSet ds = new DataSet())
                {

                    try
                    {
                        foreach (SqlParameter sqlParam in sqlParams)
                        {
                            _sqldataadapter.SelectCommand.Parameters.Add(sqlParam);
                        }

                        Baglanti_Ac();


                        ds.Locale = CultureInfo.InvariantCulture;
                        _sqldataadapter.Fill(ds);



                        return ds;

                    }

                    catch (SqlException ex)
                    {
                        throw new ApplicationException(ex.Message);
                    }

                    finally
                    {
                        Baglanti_Kapat();

                        _sqldataadapter.SelectCommand.Parameters.Clear();


                    }

                }

            }
        }


        // STORED PROCEDURE ÇALIŞTIRMA ( EXECUTENONQUERY)

        // sorgu alıp parametre olmadan ekleme silme ve güncelleme yapan kod
        public void ExecuteSPQuery(string query)

        {



            //burda commanda type olmasada oluyor







            _sqlcommand.Connection = _sqlconnection;

            _sqlcommand.CommandText = query;

            //   yenibaglanti._sqlcommand.CommandType = CommandType.StoredProcedure;

            _sqlcommand.CommandTimeout = 0;



            try

            {





                Baglanti_Ac();





                _sqlcommand.ExecuteNonQuery();

            }

            catch (SqlException ex)

            {







                throw new ApplicationException(ex.Message);

            }



            finally

            {



                Baglanti_Kapat();



            }





        }

        public void FillDropDownDev2(string query, object Ddl)

        {
            // _sqlcommand.CommandText = query;

            Type obje = Ddl.GetType();
            string objead = obje.Name.ToString();
            DropDownList drop1 = new DropDownList();
            using (SqlDataAdapter _sqldataadapter = new SqlDataAdapter(query, _sqlconnection))

            {
                _sqldataadapter.SelectCommand.CommandTimeout = 0;

                using (DataSet ds = new DataSet())

                {
                    try
                    {
                        Baglanti_Ac();

                        ds.Locale = CultureInfo.InvariantCulture;

                        _sqldataadapter.Fill(ds);

                        if (objead == "DropDownList")

                        {

                            drop1 = (DropDownList)Ddl;
                            drop1.Items.Clear();
                            drop1.DataSource = ds.Tables[0];
                            drop1.DataValueField = ds.Tables[0].Columns[0].ToString();
                            drop1.DataTextField = ds.Tables[0].Columns[1].ToString();

                            drop1.DataBind();

                            drop1.Items.Insert(0, new ListItem("Seçiniz", "0"));

                            drop1.SelectedIndex = 0;

                        }

                        // bunu sonradan ekledim aspxradiobuttonlist için
                    }
                    catch (SqlException ex)
                    {
                        throw new ApplicationException(ex.Message);
                    }
                    finally
                    { Baglanti_Kapat(); }
                }

            }

        }



        // grid doldurmak için kullanıyoruz.
        public void FillGridViewqueryDev(string query, object GView)
        {


            // _sqlcommand.CommandText = query;


            Type obje = GView.GetType();

            string objead = obje.Name.ToString();

            GridView grid1 = new GridView();





            using (SqlDataAdapter _sqldataadapter = new SqlDataAdapter(query, _sqlconnection))
            {

                _sqldataadapter.SelectCommand.CommandTimeout = 0;


                using (DataSet ds = new DataSet())
                {


                    try
                    {
                        Baglanti_Ac();


                        ds.Locale = CultureInfo.InvariantCulture;
                        _sqldataadapter.Fill(ds);

                        if (objead == "GridView")
                        {
                            grid1 = (GridView)GView;
                            grid1.DataSource = ds.Tables[0];
                            grid1.DataBind();
                            grid1.Visible = true;

                        }
                    }

                    catch (SqlException ex)
                    {
                        throw new ApplicationException(ex.Message);
                    }

                    finally
                    {

                        Baglanti_Kapat();


                    }
                }
            }
        }
    }
}