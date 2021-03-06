﻿using System;
using System.Diagnostics;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;
using Files.Filesystem;
using Windows.UI.Core;

namespace Files.Navigation
{

    public class PhotoAlbumNavActions
    {
        public static void Back_Click(object sender, RoutedEventArgs e)
        {
            
            if(App.ViewModel.tokenSource != null)
            {
                App.ViewModel.tokenSource.Cancel();
            }
            App.ViewModel.FilesAndFolders.Clear();
            

            if (History.HistoryList.Count() > 1)
            {
                App.ViewModel.TextState.isVisible = Visibility.Collapsed;
                History.AddToForwardList(History.HistoryList[History.HistoryList.Count() - 1]);
                History.HistoryList.RemoveAt(History.HistoryList.Count() - 1);
                App.ViewModel.FilesAndFolders.Clear();

                if ((History.HistoryList[History.HistoryList.Count - 1]) == Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory))
                {
                    App.PathText.Text = "Desktop";
                    foreach (Microsoft.UI.Xaml.Controls.NavigationViewItemBase NavItemChoice in MainPage.nv.MenuItems)
                    {
                        if (NavItemChoice is Microsoft.UI.Xaml.Controls.NavigationViewItem && NavItemChoice.Name.ToString() == "DesktopIC")
                        {
                            MainPage.Select.itemSelected = NavItemChoice;
                            break;
                        }
                    }
                    MainPage.accessibleContentFrame.Navigate(typeof(GenericFileBrowser), YourHome.DesktopPath, new SuppressNavigationTransitionInfo());
                    MainPage.accessibleAutoSuggestBox.PlaceholderText = "Search Desktop";
                }
                else if ((History.HistoryList[History.HistoryList.Count - 1]) == Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
                {
                    App.PathText.Text = "Documents";
                    foreach (Microsoft.UI.Xaml.Controls.NavigationViewItemBase NavItemChoice in MainPage.nv.MenuItems)
                    {
                        if (NavItemChoice is Microsoft.UI.Xaml.Controls.NavigationViewItem && NavItemChoice.Name.ToString() == "DocumentsIC")
                        {
                            MainPage.Select.itemSelected = NavItemChoice;
                            break;
                        }
                    }
                    MainPage.accessibleContentFrame.Navigate(typeof(GenericFileBrowser), YourHome.DocumentsPath, new SuppressNavigationTransitionInfo());
                    MainPage.accessibleAutoSuggestBox.PlaceholderText = "Search Documents";
                }
                else if ((History.HistoryList[History.HistoryList.Count - 1]) == (Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads"))
                {
                    App.PathText.Text = "Downloads";
                    foreach (Microsoft.UI.Xaml.Controls.NavigationViewItemBase NavItemChoice in MainPage.nv.MenuItems)
                    {
                        if (NavItemChoice is Microsoft.UI.Xaml.Controls.NavigationViewItem && NavItemChoice.Name.ToString() == "DownloadsIC")
                        {
                            MainPage.Select.itemSelected = NavItemChoice;
                            break;
                        }
                    }
                    MainPage.accessibleContentFrame.Navigate(typeof(GenericFileBrowser), YourHome.DownloadsPath, new SuppressNavigationTransitionInfo());
                    MainPage.accessibleAutoSuggestBox.PlaceholderText = "Search Downloads";
                }
                else if ((History.HistoryList[History.HistoryList.Count - 1]) == Environment.GetFolderPath(Environment.SpecialFolder.MyPictures))
                {
                    foreach (Microsoft.UI.Xaml.Controls.NavigationViewItemBase NavItemChoice in MainPage.nv.MenuItems)
                    {
                        if (NavItemChoice is Microsoft.UI.Xaml.Controls.NavigationViewItem && NavItemChoice.Name.ToString() == "PicturesIC")
                        {
                            MainPage.Select.itemSelected = NavItemChoice;
                            break;
                        }
                    }
                    MainPage.accessibleContentFrame.Navigate(typeof(PhotoAlbum), YourHome.PicturesPath, new SuppressNavigationTransitionInfo());
                    MainPage.accessibleAutoSuggestBox.PlaceholderText = "Search Pictures";
                    App.PathText.Text = "Pictures";
                }
                else if ((History.HistoryList[History.HistoryList.Count - 1]) == Environment.GetFolderPath(Environment.SpecialFolder.MyMusic))
                {
                    App.PathText.Text = "Music";
                    foreach (Microsoft.UI.Xaml.Controls.NavigationViewItemBase NavItemChoice in MainPage.nv.MenuItems)
                    {
                        if (NavItemChoice is Microsoft.UI.Xaml.Controls.NavigationViewItem && NavItemChoice.Name.ToString() == "MusicIC")
                        {
                            MainPage.Select.itemSelected = NavItemChoice;
                            break;
                        }
                    }
                    MainPage.accessibleContentFrame.Navigate(typeof(GenericFileBrowser), YourHome.MusicPath, new SuppressNavigationTransitionInfo());
                    MainPage.accessibleAutoSuggestBox.PlaceholderText = "Search Music";
                }
                else if ((History.HistoryList[History.HistoryList.Count - 1]) == (Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\OneDrive"))
                {
                    App.PathText.Text = "OneDrive";
                    foreach (Microsoft.UI.Xaml.Controls.NavigationViewItemBase NavItemChoice in MainPage.nv.MenuItems)
                    {
                        if (NavItemChoice is Microsoft.UI.Xaml.Controls.NavigationViewItem && NavItemChoice.Name.ToString() == "OneD_IC")
                        {
                            MainPage.Select.itemSelected = NavItemChoice;
                            break;
                        }
                    }
                    MainPage.accessibleContentFrame.Navigate(typeof(GenericFileBrowser), YourHome.OneDrivePath, new SuppressNavigationTransitionInfo());
                    MainPage.accessibleAutoSuggestBox.PlaceholderText = "Search OneDrive";
                }
                else if ((History.HistoryList[History.HistoryList.Count - 1]) == Environment.GetFolderPath(Environment.SpecialFolder.MyVideos))
                {
                    App.PathText.Text = "Videos";
                    foreach (Microsoft.UI.Xaml.Controls.NavigationViewItemBase NavItemChoice in MainPage.nv.MenuItems)
                    {
                        if (NavItemChoice is Microsoft.UI.Xaml.Controls.NavigationViewItem && NavItemChoice.Name.ToString() == "VideosIC")
                        {
                            MainPage.Select.itemSelected = NavItemChoice;
                            break;
                        }
                    }
                    MainPage.accessibleContentFrame.Navigate(typeof(GenericFileBrowser), YourHome.VideosPath, new SuppressNavigationTransitionInfo());
                    MainPage.accessibleAutoSuggestBox.PlaceholderText = "Search Videos";
                }
                else
                {
                    App.PathText.Text = (History.HistoryList[History.HistoryList.Count - 1]);
                    foreach (Microsoft.UI.Xaml.Controls.NavigationViewItemBase NavItemChoice in MainPage.nv.MenuItems)
                    {
                        if (NavItemChoice is Microsoft.UI.Xaml.Controls.NavigationViewItem && NavItemChoice.Name.ToString() == "LocD_IC")
                        {
                            MainPage.Select.itemSelected = NavItemChoice;
                            break;
                        }
                    }
                    App.ViewModel.MemoryFriendlyGetItemsAsync(History.HistoryList[History.HistoryList.Count - 1], GenericFileBrowser.GFBPageName); // To take into account the correct index without interference from the folder being navigated to
                }

                if (History.ForwardList.Count == 0)
                {
                    App.ViewModel.FS.isEnabled = false;
                }
                else if (History.ForwardList.Count > 0)
                {
                    App.ViewModel.FS.isEnabled = true;
                }
            }
        }

        public static void Forward_Click(object sender, RoutedEventArgs e)
        {
            if(App.ViewModel.tokenSource != null)
            {
                App.ViewModel.tokenSource.Cancel();
            }
            App.ViewModel.FilesAndFolders.Clear();

            if (History.ForwardList.Count() > 0)
            {
                App.ViewModel.TextState.isVisible = Visibility.Collapsed;
                App.ViewModel.FilesAndFolders.Clear();
                App.ViewModel.MemoryFriendlyGetItemsAsync(History.ForwardList[History.ForwardList.Count() - 1], PhotoAlbum.PAPageName);     // To take into account the correct index without interference from the folder being navigated to
                App.PathText.Text = History.ForwardList[History.ForwardList.Count() - 1];
                History.ForwardList.RemoveAt(History.ForwardList.Count() - 1);
                ArrayDiag.DumpForwardArray();

                if (History.ForwardList.Count == 0)
                {
                    App.ViewModel.FS.isEnabled = false;
                }
                else if (History.ForwardList.Count > 0)
                {
                    App.ViewModel.FS.isEnabled = true;
                }

            }
        }

        public async static void Refresh_Click(object sender, RoutedEventArgs e)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                if(App.ViewModel.tokenSource != null)
                {
                    App.ViewModel.tokenSource.Cancel();
                }
                App.ViewModel.TextState.isVisible = Visibility.Collapsed;
                App.ViewModel.FilesAndFolders.Clear();
                App.ViewModel.MemoryFriendlyGetItemsAsync(App.PathText.Text, PhotoAlbum.PAPageName);
                if ((History.HistoryList[History.HistoryList.Count - 1]) == Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory))
                {
                    App.PathText.Text = "Desktop";

                }
                else if ((History.HistoryList[History.HistoryList.Count - 1]) == Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
                {
                    App.PathText.Text = "Documents";

                }
                else if ((History.HistoryList[History.HistoryList.Count - 1]) == (Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads"))
                {
                    App.PathText.Text = "Downloads";

                }
                else if ((History.HistoryList[History.HistoryList.Count - 1]) == Environment.GetFolderPath(Environment.SpecialFolder.MyPictures))
                {

                    App.PathText.Text = "Pictures";
                }
                else if ((History.HistoryList[History.HistoryList.Count - 1]) == Environment.GetFolderPath(Environment.SpecialFolder.MyMusic))
                {
                    App.PathText.Text = "Music";

                }
                else if ((History.HistoryList[History.HistoryList.Count - 1]) == (Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\OneDrive"))
                {
                    App.PathText.Text = "OneDrive";

                }
                else if ((History.HistoryList[History.HistoryList.Count - 1]) == Environment.GetFolderPath(Environment.SpecialFolder.MyVideos))
                {
                    App.PathText.Text = "Videos";

                }
                else
                {
                    App.PathText.Text = (History.HistoryList[History.HistoryList.Count - 1]);

                }
            });
            
        }
    }
}