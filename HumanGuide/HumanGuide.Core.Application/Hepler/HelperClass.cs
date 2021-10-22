using HumanGuide.Core.Application.DTOs;
using HumanGuide.Core.Domain.Entities;
using System.Collections.Generic;

namespace HumanGuide.Core.Application.Hepler
{
    public class HelperClass
    {
        public static List<ConnecteHuman> CreateListOfConnecteHuman(int humanId, List<SetConnecteHumanDto> connecteHumans)
        {
            List<ConnecteHuman> list = new();

            foreach (var connecteHuman in connecteHumans)
            {
                list.Add(new ConnecteHuman { HumanId = humanId, ConnecteHumanId = connecteHuman.ConnecteHumanId, ConnectionType = connecteHuman.ConnectionType });
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
