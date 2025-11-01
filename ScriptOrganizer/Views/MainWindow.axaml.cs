using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using ScriptOrganizer.ViewModels;

namespace ScriptOrganizer.Views;

public partial class MainWindow : Window
{
   public MainWindow()
   {
      InitializeComponent();
   }

   private async void Button_OnClick(object? sender, RoutedEventArgs e)
   {
      FilePickerFileType botcScriptFilter = new("BOTC Script")
                                            {
                                               Patterns = ["*.json"],
                                               MimeTypes = ["text/json"]
                                            };

      var filePickerOptions = new FilePickerOpenOptions()
                              {
                                 AllowMultiple = false,
                                 FileTypeFilter = [botcScriptFilter],
                                 Title = "Select Script"
                              };
      var files = await StorageProvider.OpenFilePickerAsync(filePickerOptions);
      if (files.Count > 0)
      {
         var file = files[0];
         (DataContext as MainWindowViewModel)!.LoadScript(file.TryGetLocalPath()!);
      }

   }
}
