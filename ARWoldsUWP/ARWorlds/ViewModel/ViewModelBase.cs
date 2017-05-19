using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;
using Windows.Data.Xml.Dom;
using Windows.Storage;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ARWorlds.Handler;
using ARWorlds.Model;
using ARWorlds.Provider;
using ARWorlds.ViewModel.Commands;

namespace ARWorlds.ViewModel
{
    public class ViewModelBase : ObservableCollection<Model3D>
    {
        public MailCommand MailCommand { get; set; }
        public ChooseModelCommand ChooseModelCommand { get; set; }

        private List<Model3D> _list;
        private Model3D _selected;
        public ViewModelBase()
        {
            getModels3D();
            this.MailCommand = new MailCommand(this);
            this.ChooseModelCommand = new ChooseModelCommand(this);
        }

        public Model3D SelectedModel3D
        {
            get { return _selected; }
            set
            {
                _selected = value;
                //  RaisePropertyChanged(() => SelectedStation);
                //  showAirStatus(value);
            }
        }

        public async void getModels3D()
        {
            List = await Model3DHandler.getData();

            foreach (Model3D model3D in List)
            {
                Add(model3D);
            }
        }

        public List<Model3D> List
        {
            get { return _list; }
            set
            {
                _list = value;
                //  RaisePropertyChanged(() => List);
            }
        }


        public async void MailMethod()
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            picker.FileTypeFilter.Add(".blend");
            picker.FileTypeFilter.Add(".fbx");
            picker.FileTypeFilter.Add(".obj");


            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                await ComposeEmail(new Contact(), "xd", file);
            }
            else
            {
                //  this.textBlock.Text = "Operation cancelled.";
            }
        }

        public void ChoseModelMethod(string modelname)
        {
            
            AppVariables.CurrentModel = modelname;
            GoToMainPage();
            Debug.WriteLine(modelname);

        }

        public static void GoToMainPage()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainPage)); ;
        }

        private async Task ComposeEmail(Windows.ApplicationModel.Contacts.Contact recipient,
            string messageBody,
            StorageFile attachmentFile)
        {
            var emailMessage = new Windows.ApplicationModel.Email.EmailMessage();
            emailMessage.Body = messageBody;

            if (attachmentFile != null)
            {
                var stream = Windows.Storage.Streams.RandomAccessStreamReference.CreateFromFile(attachmentFile);

                var attachment = new Windows.ApplicationModel.Email.EmailAttachment(
                    attachmentFile.Name,
                    stream);

                emailMessage.Attachments.Add(attachment);
            }

            var email = recipient.Emails.FirstOrDefault<Windows.ApplicationModel.Contacts.ContactEmail>();
            if (email != null)
            {
                var emailRecipient = new Windows.ApplicationModel.Email.EmailRecipient(email.Address);
                emailMessage.To.Add(emailRecipient);
            }

            await Windows.ApplicationModel.Email.EmailManager.ShowComposeNewEmailAsync(emailMessage);

        }

        private void UpdateLiveTile()
        {
            XmlDocument tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWide310x150PeekImageAndText02);

            XmlNodeList tileTextArtibutes = tileXml.GetElementsByTagName("text");
            XmlNodeList tileImageArtibutes = tileXml.GetElementsByTagName("image");

            ((XmlElement)tileImageArtibutes[0]).SetAttribute("src", "C:\\Users\\pluszak\\Desktop\\pluszak\\Informatyka 2014-2017\\Universal Windows Platform\\ARWoldsUWP\\ARWorlds\\Images\\3dmodeling.png");
            var model = List[0].Name;
            tileTextArtibutes[0].InnerText = model;
            
            TileNotification tileNotification = new TileNotification(tileXml);
            tileNotification.ExpirationTime = DateTimeOffset.UtcNow.AddDays(3);
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);
        }
    }
}
