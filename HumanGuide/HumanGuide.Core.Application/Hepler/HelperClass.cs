using HumanGuide.Core.Application.DTOs;
using HumanGuide.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace HumanGuide.Core.Application.Hepler
{
    public class HelperClass
    {
        public static List<ConnectedHuman> CreateListOfConnectedHuman(int humanId, List<SetConnectedHumanDto> connectedHumans)
        {
            List<ConnectedHuman> list = new();
            list.AddRange(connectedHumans.Select
            (
              connectedHuman => new ConnectedHuman { HumanId = humanId, BaseConnectedHumanId = connectedHuman.BaseConnectedHumanId, ConnectionType = connectedHuman.ConnectionType })
            );
            return list;
        }

        public static List<Human2Phone> CreateListOfHuman2Phone(int humanId, List<int> phoneIds)
        {
            List<Human2Phone> list = new();
            list.AddRange(phoneIds.Select(item => new Human2Phone { HumanId = humanId, PhoneId = item }));
            return list;
        }
    }
}
