using NetCoreReact.Models;
using System.Threading.Tasks;

namespace NetCoreReact.Services.Data
{
	public interface ISampleDAO
	{
		Task<ParticipantsModel> UnauthenticatedSampleGet();
		void AddParticipant(InputModel user);
		Task<int> DoesParticipantExist(string participantName);
		Task<int> GetNumberOfParticipants();
		Task<int> HasParticipantDrawn(string participantName);
		Task<PresentModel> GetRandomParticipant(string participantName);
		void SetTakenParticipant(string takenParticipantName);
		void SetParticipantDrawFlag(string participantName);
		void SaveDrawnParticipant(string takenParticipantName, string participantName);
	}
}
