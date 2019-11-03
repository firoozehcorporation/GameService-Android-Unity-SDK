using System.Collections.Generic;
using FiroozehGameServiceAndroid.Enums.GSLive;
using FiroozehGameServiceAndroid.Models;
using FiroozehGameServiceAndroid.Models.GSLive;

namespace FiroozehGameServiceAndroid.Interfaces.GSLive.Command
{
    /// <summary>
    /// Represents GSLive Command Event Listener
    /// </summary>
    public interface GSLiveCommandListeners
    {
        // Major Listeners
        /// <summary>
        /// The result returns this function if you request a game room search by a specific rule
        /// </summary>
        /// <param name="rooms">A list of game rooms According by Rule</param>
        void OnAvailableRooms(List<Room> rooms);
      
        
        /// <summary>
        /// The result in this function is AutoMatch if you request a game
        /// </summary>
        /// <param name="status">Request status</param>
        /// <param name="players">List of players</param>
        void OnAutoMatchUpdate(AutoMatchStatus status,List<User> players);
        
        // Invite Listeners
        /// <summary>
        /// If you request to receive invitations to the user, the result will be returned in this function.
        /// </summary>
        /// <param name="invites">List of invitations</param>
        void OnInviteInbox (List<Invite> invites);
        
        /// <summary>
        /// The result returns this function if you invite a user and are successful.
        /// </summary>
        void OnInviteSend();
        
        /// <summary>
        /// The result returns this function if you request a user search query with a nickname.
        /// </summary>
        /// <param name="users">List of players</param>
        void OnFindUsers(List<User> users);
        
        /// <summary>
        /// If a player sends you an invitation, the result will be returned
        /// </summary>
        /// <param name="invite">Invitation information</param>
        void OnInviteReceive(Invite invite);
    }
}