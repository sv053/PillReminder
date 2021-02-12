using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillReminder.Views
{
    public class OffersMasterDetailPageMasterMenuItem
    {
        public OffersMasterDetailPageMasterMenuItem()
        {
            TargetType = typeof(OffersMasterDetailPageMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}