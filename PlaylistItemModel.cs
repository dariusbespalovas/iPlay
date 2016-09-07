namespace iPlay
{
	public class PlaylistItemModel
	{
		public string Name { get; set; }
		public string Path { get; set; }
		public int Duration { get; set; }

		public string DurationFormated
		{
			get {
				return string.Format("{0:0}:{1:00}:{2:00}", Duration / 60 / 60, Duration / 60 % 60, Duration % 60);
			}
		}
	}
}
