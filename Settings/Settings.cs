using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settings
{
    public abstract class Settings{
	
	//Ctor
        public Settings()
        {

        }

	// Opens the settings file. Must be overriden
	public abstract void openSettingsFile();
	
	// Closes the settings file. Maybe done in dtor
	public virtual void closeSettingsFile();

	/// <summary>
	/// Saves the settings file.
	/// </summary>
	/// <returns>RESULT</returns>
	public virtual void saveSettingsFile();
	
	/// <summary>
	/// Deletes the settings file.
	/// </summary>
	/// <returns>RESULT</returns>
	public virtual void deleteSettingsFile();


	protected readonly string m_filePath;
	bool fileOpen = false;
};
}
