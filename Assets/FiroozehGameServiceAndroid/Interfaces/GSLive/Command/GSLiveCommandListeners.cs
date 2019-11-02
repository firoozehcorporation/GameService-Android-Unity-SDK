using System.Collections.Generic;
using FiroozehGameServiceAndroid.Enums.GSLive;
using FiroozehGameServiceAndroid.Models;
using FiroozehGameServiceAndroid.Models.GSLive;

namespace FiroozehGameServiceAndroid.Interfaces.GSLive.Command
{
    public interface GSLiveCommandListeners
    {
        // Major Listeners
        void OnAvailableRooms(List<Room> rooms);
        void OnAutoMatchUpdate(AutoMatchStatus status,List<User> players);
        
        // Invite Listeners
        void OnInviteInbox (List<Invite> invites);
        void OnInviteSend();
        void OnFindUsers(List<User> users);
        void OnInviteReceive(Invite invite);
    }
}