using Godot;
using System;

/// <summary>
/// This is a C# wrapper for Dialogic.
/// </summary>
public class DialogicSharp : Node
{
    //list of all GDScript references used by dialogic
    private static GDScript dialog_node;

    private static GDScript dialog_class;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        dialog_node = (GDScript) GD.Load("res://addons/dialogic/Nodes/dialog_node.gd");
        dialog_class = (GDScript) GD.Load("res://addons/dialogic/Other/dialogic_class.gd");
    }

    
    #region dialog_class
    public Node Start(string timeline, bool debugMode = true)
    {
        return (Node)dialog_class.Call("start", timeline, debugMode);
    }   


    #endregion

    #region dialog_node
    /// <summary>
    /// Loads (or reloads) Dialogic configuration files and theme.
    /// </summary>
    public void LoadConfigFiles()
    {
        dialog_node.Call("load_config_files");
    }

    /// <summary>
    /// This method ensures that the dialog is displayed at the correct
	/// size and position in the screen. 
    /// </summary>
    public void ResizeMain()
    {
        dialog_node.Call("resize_main");
    }

    /// <summary>
    /// Updates the dialog to the current dialog in the timeline.
    /// </summary>
    /// <param name="dialogPath">The relative path of the dialog within its particular timeline, in the /Timelines directory.</param>
    public void SetCurrentDialog(string dialogPath)
    {
        dialog_node.Call("set_current_dialog", dialogPath);
    }

    #endregion
}