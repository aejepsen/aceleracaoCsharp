namespace election_day
/// ok
{
    public class BallotBox
    {
        public int VotesOption1;
        public int VotesOption2;
        public int VotesOption3;
        public int VotesNull;

        public void Start()
        {
            // Ao ser executado, a função Start() deve definir os valores de votos para 0.
            VotesOption1 = 0;
            VotesOption2 = 0;
            VotesOption3 = 0;
            VotesNull = 0;

        }

        public void UniqueVote(int voteOption)
        {
                switch (voteOption)
                {
                    case 1:
                        VotesOption1++;
                        break;
                    case 2:
                        VotesOption2++;
                        break;
                    case 3:
                        VotesOption3++;
                        break;
                    case 0:
                        VotesNull++;
                        break;
                    default:
                        break;
                }
        }

        public void MultipleVotes(int[] votesOption)
        {
            for (int i = 0; i < votesOption.Length; i++)
            {
                switch (votesOption[i])
                {
                    case 1:
                        VotesOption1++;
                        break;
                    case 2:
                        VotesOption2++;
                        break;
                    case 3:
                        VotesOption3++;
                        break;
                    case 0:
                        VotesNull++;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
