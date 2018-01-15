using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core.Models;
using Newtonsoft.Json;

namespace MSO.StimmApp.Core.Maps
{
    public class AutoCompleteResult : ModelBase
    {
        private string status;
        private List<AutoCompletePrediction> autoCompletePlaces = new List<AutoCompletePrediction>();

        public AutoCompleteResult() : base(true)
        {

        }

        [JsonProperty("status")]
        public string Status
        {
            get => this.status;
            set => this.Set(ref this.status, value);
        }

        [JsonProperty("predictions")]
        public List<AutoCompletePrediction> AutoCompletePlaces
        {
            get => this.autoCompletePlaces;
            set => this.Set(ref this.autoCompletePlaces, value);
        }
    }
}
