using System;

namespace payroll_app.codeHelper
{
    public static class RandomImage
    {
        private static string imgpath = "/images/stock/person/";

        public static int rand()
        {
            var r = new Random();
            //shows minvalue up to maxvalue-1 
            return r.Next(1, 3);
        }

        public static string Randuserimgchooser(string hostenv)
        {
            if (rand().Equals(1))
            {
                return hostenv + imgpath + "boy" + rand() + ".png";
            }
            else
            {
                return hostenv + imgpath + "girl" + rand() + ".png";
            }
        }

        public static string Userimgchooser(string hostenv,string gender = null)
        {
            if (gender != null)
            {
                if (gender.ToLower().Equals("male"))
                {
                    return hostenv + imgpath + "boy" + rand() + ".png";
                }
                else if (gender.ToLower().Equals("female"))
                {
                    return hostenv + imgpath + "girl" + rand() + ".png";
                }
                else
                {
                    return Randuserimgchooser(hostenv);
                }
            }
            else
            {
                return Randuserimgchooser(hostenv);
            }
        }






        /*public static string randuserimgchooser(this IHostingEnvironment _hostingEnvironment, int random)
        {
            var imgpath = _hostingEnvironment.WebRootPath + "/images/stock/person/";
            if (rand().Equals(1))
            {
                return imgpath + "boy" + rand() + ".png";
            }
            else
            {
                return imgpath + "girl" + rand() + ".png";
            }
        }

        public static string userimgchooser(this IHostingEnvironment _hostingEnvironment, int random, string gender = null)
        {
            var imgpath = _hostingEnvironment.WebRootPath + "/images/stock/person/";
            if (gender != null)
            {
                if (rand().Equals(1))
                {
                    return imgpath + "boy" + rand() + ".png";
                }
                else if(gender.ToLower().Equals("female"))
                {
                    return imgpath + "girl" + rand() + ".png";
                }
                else
                {

                }
            }
            else
            {
                if (rand().Equals(1))
                {
                    return imgpath + "boy" + rand() + ".png";
                }
                else
                {
                    return imgpath + "girl" + rand() + ".png";
                }
            }
        }*/
    }
}
