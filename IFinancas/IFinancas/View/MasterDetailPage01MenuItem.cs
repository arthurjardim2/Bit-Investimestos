using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFinancas.View
{

    public class MasterDetailPage01MenuItem
    {
        public MasterDetailPage01MenuItem(Type targetType)
        {
            TargetType = targetType;
            //TargetType = typeof(MasterDetailPage01Detail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}