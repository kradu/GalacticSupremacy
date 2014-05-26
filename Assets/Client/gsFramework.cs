namespace gsFramework
{
	/*
	 * SolReg's represent the Solar Regions of the Gameworld. Solar
	 * Regions have a sector ID, belonging to the sector that contains
	 * them, an individual ID, their x and z coordinates in the 
	 * sector-space, and a texture.
	 */
	public struct SolReg {
		public int sector;		// ID of sector that contains the SolReg
		public int id;			// ID of this SolReg
		public float x, z;		// coordinates of the SolReg in the sector-space.
		public float scale;		// indicator of the planets size
		public string texture;	// the planets texture for the map
		public int[] adjacent;	// ID's of adjacent SolReg
		public int owner;		// owners playerID
	}
}