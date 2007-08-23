namespace Commanigy.Iquomi.Ui {
	/// <summary>
	/// 
	/// </summary>
	public class State {
		public static readonly string DESIGN = "D";
		public static readonly string PROVISIONED = "P";
		public static readonly string OFFLINE = "O";
		public static readonly string RETIRED = "R";

		private string state_;

		public State(string state) {
			this.state_ = state;
		}

		public override string ToString() {
			if (state_ == DESIGN) {
				return "Design";
			}
			else if (state_ == PROVISIONED) {
				return "Provisioned";
			}
			else if (state_ == OFFLINE) {
				return "Offline";
			}
			else if (state_ == RETIRED) {
				return "Retired";
			}

			return "Unknown";
		}

	}
}