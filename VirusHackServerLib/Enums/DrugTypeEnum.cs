using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusHackServerLib.Enums {
    public enum DrugTypeEnum {
        None,
        Immunomodulators,
        Vitamins,
        BADs,
        Antibiotics
    }
    public enum FrequencyAdmissionEnum {
        None,
        EveryDay,
        EveryWeek,
        AfterDay
    }
    public enum FeaturesReceptionEnum {
        None,
        BeforeEating,
        InEating,
        AfterEating
    }
}
