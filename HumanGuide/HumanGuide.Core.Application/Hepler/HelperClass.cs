using HumanGuide.Core.Domain.Entities;
using System.Collections.Generic;

namespace HumanGuide.Core.Application.Hepler
{
    public class HelperClass
    {
        public static List<ConnecteHuman> CreateListOfConnecteHuman(int humanId, List<int> connecteHumanIds)
        {
            List<ConnecteHuman> list = new();

            foreach (var item in connecteHumanIds)
            {
                list.Add(new ConnecteHuman { HumanId = humanId, ConnecteHumanId = item });
            }
            return list;
        }

        public static List<Human2Phone> CreateListOfHuman2Phone(int humanId, List<int> phoneIds)
        {
            List<Human2Phone> list = new();


            foreach (var item in phoneIds)
            {
                list.Add(new Human2Phone { HumanId = humanId, PhoneId = item });
            }
            return list;
        }
    }
}
