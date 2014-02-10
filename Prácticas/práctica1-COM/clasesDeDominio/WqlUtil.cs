using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Management;

namespace ProoOfConceptInfo
{
    /// <summary>
    /// WqlUtil Clase para obtener información de la pc
    /// </summary>
    class WqlUtil
    {

        private static WqlObjectQuery wqlQuery = new WqlObjectQuery("Select * from Win32_BaseBoard");        
        private static ManagementObjectSearcher searcher = new ManagementObjectSearcher(wqlQuery);
       
        /// <summary>
        /// Ejecutar BaseBoard
        /// </summary>
        /// <returns></returns>
        public static string executeQueryDescriptionBaseBoard()
        {
            String description = "";
            if (searcher.Get() != null && searcher.Get().Count > 0)
            {
                foreach (ManagementObject baseboard in searcher.Get())
                {
                    if (baseboard.GetPropertyValue("Description") != null)
                    {
                        description = baseboard.GetPropertyValue("Description").ToString();
                        break;
                    }
                }
            }
            return description;
        }

        /// <summary>
        /// Ejecutar BaseBoard
        /// </summary>
        /// <returns></returns>
        public static string executeQuerySerialBaseBoard()
        {
            String serialNumber = "";
            
            if (searcher.Get() != null && searcher.Get().Count > 0)
            {
                foreach (ManagementObject baseboard in searcher.Get())
                {
                    if (baseboard.GetPropertyValue("SerialNumber") != null)
                    {
                        serialNumber = baseboard.GetPropertyValue("SerialNumber").ToString();
                        break;
                    }
                }
            }
            return serialNumber;
        }

        /// <summary>
        /// Método checksum
        /// </summary>
        /// <returns></returns>
        public string checksum()
        {
              return "00123113asdasd";
        }
    }
}
