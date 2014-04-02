using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using eBooks2goV5.bel;

namespace eBooks2goV5.dal
{
    public class dal
    {
        //SQL Connection string 
        string ConnectionString = ConfigurationManager.AppSettings["dbcs"].ToString();

        #region Get Prodcat Details
        public DataTable getprodcat(bel.bel _pc)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_getprodcatbyid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@ppcid", _pc.pcid);
                cmd.Parameters.AddWithValue("@pResult", _pc.pResult);
                cmd.Parameters["@pResult"].Size = 250;
                cmd.Parameters["@pResult"].Direction = ParameterDirection.Output;
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();
                DataTable dprodcat = new DataTable();
                dprodcat.Load(rdr);
                return dprodcat;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        #endregion

        #region Get Products Details
        public DataTable getproducts(bel.bel _pc)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_getproductbyid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@ppcid", _pc.pcid);
                cmd.Parameters.AddWithValue("@pprodid", _pc.prodid);
                cmd.Parameters.AddWithValue("@pResult",_pc.pResult);
                cmd.Parameters["@pResult"].Size = 250;
                cmd.Parameters["@pResult"].Direction = ParameterDirection.Output;
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();
                DataTable dprodcat = new DataTable();
                dprodcat.Load(rdr);
                return dprodcat;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }
        #endregion

        #region generate shoppingcart master and details
        public Int64? Inscart(cartmasterbel _cartmasterbel, List<cartproductsbel> _cartproductbel, List<ebfileuploadbel> _ebfileuploadbel)
        {

            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            con.Open();
            SqlTransaction transaction = null;
            try
            {
              
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("sp_newcartmaster", con,transaction);
                cmd.CommandType = CommandType.StoredProcedure;

                #region inputparams
                cmd.Parameters.AddWithValue("@pcustomerid", _cartmasterbel.customerid);
                cmd.Parameters.AddWithValue("@pprodcatid", _cartmasterbel.prodcatid);
                cmd.Parameters.AddWithValue("@pofferselected", _cartmasterbel.offerselected);
                cmd.Parameters.AddWithValue("@ptitle", _cartmasterbel.title);
                cmd.Parameters.AddWithValue("@pauthor", _cartmasterbel.author);
                cmd.Parameters.AddWithValue("@pbworcolor", _cartmasterbel.bworcolor);
                cmd.Parameters.AddWithValue("@pbooklanguage", _cartmasterbel.booklanguage);
                cmd.Parameters.AddWithValue("@pprjcompdate", _cartmasterbel.prjcompdate);
                cmd.Parameters.AddWithValue("@pmanscrpitdesc", _cartmasterbel.manscrpitdesc);
                cmd.Parameters.AddWithValue("@pcartrefcode", _cartmasterbel.cartrefcode);
                //cmd.Parameters.AddWithValue("@pcartmastercreateddate", _cartmasterbel.cartmastercreateddate); //reason for this comment line is 
                cmd.Parameters.AddWithValue("@ptotalpages", _cartmasterbel.totalpages);
                cmd.Parameters.AddWithValue("@ptotalimages", _cartmasterbel.totalimages);
                cmd.Parameters.AddWithValue("@ptotalfenotes", _cartmasterbel.totalfenotes);
                cmd.Parameters.AddWithValue("@ptotalweblinks", _cartmasterbel.totalweblinks);
                cmd.Parameters.AddWithValue("@pnestedtoc", _cartmasterbel.nestedtoc);
                cmd.Parameters.AddWithValue("@pcoloredfonts", _cartmasterbel.coloredfonts);
                cmd.Parameters.AddWithValue("@pmultipleselection", _cartmasterbel.multipleselection);
                cmd.Parameters.AddWithValue("@pdoublecolumn", _cartmasterbel.doublecolumn);
                cmd.Parameters.AddWithValue("@ptextboxboundry", _cartmasterbel.textboxboundry);
                cmd.Parameters.AddWithValue("@pdropcaps", _cartmasterbel.dropcaps);
                cmd.Parameters.AddWithValue("@plists", _cartmasterbel.lists);
                cmd.Parameters.AddWithValue("@pcallouts", _cartmasterbel.callouts);
                cmd.Parameters.AddWithValue("@pcenteredtext", _cartmasterbel.centeredtext);
                cmd.Parameters.AddWithValue("@pelementscost", _cartmasterbel.elementscost);
                cmd.Parameters.AddWithValue("@ptotalav", _cartmasterbel.totalav);
                cmd.Parameters.AddWithValue("@pcoverdesign", _cartmasterbel.coverdesign);
                cmd.Parameters.AddWithValue("@pdistribution", _cartmasterbel.distribution);
                cmd.Parameters.AddWithValue("@psocialmedia", _cartmasterbel.socialmedia);
                cmd.Parameters.AddWithValue("@ppressrelease", _cartmasterbel.pressrelease);
                cmd.Parameters.AddWithValue("@pemailcampain", _cartmasterbel.emailcampain);
                cmd.Parameters.AddWithValue("@pwebsiteandblog", _cartmasterbel.websiteandblog);
                cmd.Parameters.AddWithValue("@preadallowedtext", _cartmasterbel.readallowedtext);
                cmd.Parameters.AddWithValue("@ptotalanimationpages", _cartmasterbel.totalanimationpages);
                cmd.Parameters.AddWithValue("@pinteractiveselfassessmentqa", _cartmasterbel.interactiveselfassessmentqa);
                cmd.Parameters.AddWithValue("@pprojfilename", _cartmasterbel.projfilename);
                cmd.Parameters.AddWithValue("@pinvoiceamt", _cartmasterbel.invoiceamt);
                cmd.Parameters.AddWithValue("@precstatus", 1);
                #endregion
                //return "";

                #region output params
                cmd.Parameters.AddWithValue("@pcmid", _cartmasterbel.cmid);
                cmd.Parameters["@pcmid"].SqlDbType = SqlDbType.BigInt;
                cmd.Parameters["@pcmid"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@pResult", _cartmasterbel.pResult);
                cmd.Parameters["@pResult"].Size = 250;
                cmd.Parameters["@pResult"].Direction = ParameterDirection.Output;
                #endregion

                cmd.ExecuteNonQuery();
                //cmd = null;
                Int64? pcmid= (long?)cmd.Parameters["@pcmid"].Value; //return the cmid.
                //return "";

                foreach (cartproductsbel _cartproduct in _cartproductbel)
                {
                    cmd = new SqlCommand("sp_newcartproducts", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    #region input pararms
                    cmd.Parameters.AddWithValue("@pcmid", pcmid);
                    //cmd.Parameters["@pcmid"].Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@pprodid", _cartproduct.prodid);
                    cmd.Parameters.AddWithValue("@peisbn", _cartproduct.eisbn);
                    #endregion

                    #region output params
                    cmd.Parameters.AddWithValue("@pResult", _cartproduct.pResult);
                    cmd.Parameters["@pResult"].Size = 250;
                    cmd.Parameters["@pResult"].Direction = ParameterDirection.Output;
                    #endregion

                    cmd.ExecuteNonQuery();
                    //cmd = null;
                }
                //cmd = null;
             
                foreach (ebfileuploadbel _cartfiles in _ebfileuploadbel)
                {
                    cmd = new SqlCommand("sp_newebfileupload", con, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    #region input pararms
                    cmd.Parameters.AddWithValue("@pcmid", pcmid);                  
                    cmd.Parameters.AddWithValue("@pupfilename", _cartfiles.upfilename);
                    #endregion

                    #region output params
                    cmd.Parameters.AddWithValue("@pResult", _cartfiles.pResult);
                    cmd.Parameters["@pResult"].Size = 250;
                    cmd.Parameters["@pResult"].Direction = ParameterDirection.Output;
                    #endregion

                    cmd.ExecuteNonQuery();
                }
                transaction.Commit();
                return (Int64?)cmd.Parameters["@pcmid"].Value; //return the presult
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                cmd.Dispose();
              
                con.Close();
                con.Dispose();
            }
        }
        #endregion

        #region insert new customer
        public object insertnewcustomer(insertnewcustomerbel _insertnewcustomerbel) //the return type is object coz it may return int or may return string.
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_newcustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                #region inputparams
                cmd.Parameters.AddWithValue("@pemailid", _insertnewcustomerbel.emailid);
                cmd.Parameters.AddWithValue("@ppassword", _insertnewcustomerbel.password);
                cmd.Parameters.AddWithValue("@pfirstname", _insertnewcustomerbel.firstname);
                cmd.Parameters.AddWithValue("@plastname", _insertnewcustomerbel.lastname);
                cmd.Parameters.AddWithValue("@pcompanyname", _insertnewcustomerbel.companyname);
                cmd.Parameters.AddWithValue("@paddress1", _insertnewcustomerbel.address1);
                cmd.Parameters.AddWithValue("@paddress2", _insertnewcustomerbel.address2);
                cmd.Parameters.AddWithValue("@pcity", _insertnewcustomerbel.city);
                cmd.Parameters.AddWithValue("@pcountryid", _insertnewcustomerbel.countryid);
                cmd.Parameters.AddWithValue("@pstateid", _insertnewcustomerbel.stateid);
                cmd.Parameters.AddWithValue("@pzipCode", _insertnewcustomerbel.zipCode);
                cmd.Parameters.AddWithValue("@pphone", _insertnewcustomerbel.phone);
                cmd.Parameters.AddWithValue("@pfax", _insertnewcustomerbel.fax);
                cmd.Parameters.AddWithValue("@pcustomertype", _insertnewcustomerbel.customertype);

                #endregion

                #region output params
                cmd.Parameters.AddWithValue("@pcustomerid", _insertnewcustomerbel.customerid);
                cmd.Parameters["@pcustomerid"].SqlDbType = SqlDbType.BigInt;
                cmd.Parameters["@pcustomerid"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@pResult", _insertnewcustomerbel.pResult);
                cmd.Parameters["@pResult"].Size = 250;
                cmd.Parameters["@pResult"].Direction = ParameterDirection.Output;
                #endregion

                cmd.ExecuteNonQuery();
                if(cmd.Parameters["@pcustomerid"].Value!=System.DBNull.Value)
                return (long?)cmd.Parameters["@pcustomerid"].Value; //return the customer id.
                else
                    return (string)cmd.Parameters["@pResult"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }
        #endregion

        #region get cartmaster details
        public DataTable getcartmaster(cartmasterbel _cartmasterbel)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_getcartmaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@pcmid", _cartmasterbel.cmid);
                cmd.Parameters.AddWithValue("@pResult", _cartmasterbel.pResult);
                cmd.Parameters["@pResult"].Size = 250;
                cmd.Parameters["@pResult"].Direction = ParameterDirection.Output;
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();
                DataTable datatablegetcartmaster = new DataTable();
                datatablegetcartmaster.Load(rdr);
                return datatablegetcartmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }
        #endregion


        #region get countries
        public DataTable getcountries()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("getcountries", con);
            cmd.CommandType = CommandType.StoredProcedure;
            Countries _countries = new Countries();
            try
            {
                cmd.Parameters.AddWithValue("@pResult", _countries.pResult);
                cmd.Parameters["@pResult"].Size = 250;
                cmd.Parameters["@pResult"].Direction = ParameterDirection.Output;
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();
                DataTable datatablecountries = new DataTable();
                datatablecountries.Load(rdr);
                return datatablecountries;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }
        #endregion

        #region get countries
        public DataTable getstates(States _state)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("getstates", con);
            cmd.CommandType = CommandType.StoredProcedure;
           
            try
            {
                cmd.Parameters.AddWithValue("@pcountryid", _state.countryid);
                cmd.Parameters.AddWithValue("@pResult", _state.pResult);
                cmd.Parameters["@pResult"].Size = 250;
                cmd.Parameters["@pResult"].Direction = ParameterDirection.Output;
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();
                DataTable dtstates = new DataTable();
                dtstates.Load(rdr);
                return dtstates;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }
        #endregion

    }
}