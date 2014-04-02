using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using eBooks2goV5.dal;
using System.Web.UI;
using System.Web.UI.WebControls;
using eBooks2goV5.bel;

namespace eBooks2goV5.bll
{
    public class bll
    {
        #region Get Prodcat Details
        public DataTable getprodcat(bel.bel _pc)        
        {
            dal.dal objprodcatdal = new dal.dal();

            try
            {
                return objprodcatdal.getprodcat(_pc);
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                objprodcatdal = null;
            }
        }

        #endregion

        #region Get Products Details
        public DataTable getproducts(bel.bel _pc)
        {
            dal.dal objprodcatdal = new dal.dal();
            try
            {
                return objprodcatdal.getproducts(_pc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objprodcatdal = null;
            }
        }
        #endregion


        #region insert shoppingcart and details
        public Int64? insertnewcartmaster(cartmasterbel _cartmasterbel, List<cartproductsbel> _cartproductbel, List<ebfileuploadbel> _ebfileuploadbel)
        {

            dal.dal objinsertcart = new dal.dal();
            try
            {
                return objinsertcart.Inscart(_cartmasterbel, _cartproductbel, _ebfileuploadbel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objinsertcart = null;
            }
        }
        #endregion

        #region insert new customer
        public object insertnewcustomer(bel.insertnewcustomerbel _insertnewcustomerbel)
        {
            dal.dal objinsertnewcustomerdal = new dal.dal();
            try
            {
                return objinsertnewcustomerdal.insertnewcustomer(_insertnewcustomerbel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objinsertnewcustomerdal = null;
            }
        }
        #endregion

        #region get cartmaster details
        public DataTable getcartmaster(cartmasterbel _cartmasterbel)
        {
            dal.dal objgetcartmasterdal = new dal.dal();

            try
            {
                return objgetcartmasterdal.getcartmaster(_cartmasterbel);
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                objgetcartmasterdal = null;
            }
        }
        #endregion

        #region getcountries
        public DataTable getcountries()
        {
            dal.dal objgetcountriesdal = new dal.dal();

            try
            {
                return objgetcountriesdal.getcountries();
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                objgetcountriesdal = null;
            }
        }
        #endregion

         #region get states
        public DataTable getstates(States _state)
        {
            dal.dal objgetstatesdal = new dal.dal();

            try
            {
                return objgetstatesdal.getstates(_state);
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                objgetstatesdal = null;
            }
        }
         #endregion
    }
}