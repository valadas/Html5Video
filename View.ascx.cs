/*
' Copyright (c) 2017  Daniel Valadas
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Common;

namespace Eraware.Modules.Html5Video
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from Html5VideoModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : Html5VideoModuleBase, IActionable
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(Settings.Contains("MP4Video"))
                {
                    string html = @"<video";
                    if (Settings.Contains("ReplaceWithImage"))
                    {
                        bool replaceWithImage = false;
                        bool.TryParse(Settings["ReplaceWithImage"].ToString(), out replaceWithImage);
                        if (replaceWithImage)
                        {
                            html += @" class=""hidden-xs""";
                        }
                    }
                        
                    if (Settings.Contains("Autoplay") && Settings["Autoplay"].ToString() == "True")
                        html += " autoplay";
                    if (Settings.Contains("Loop") && Settings["Loop"].ToString() == "True")
                        html += " loop";
                    if (Settings.Contains("Controls") && Settings["Controls"].ToString() == "True")
                        html += " controls";
                    if (Settings.Contains("Muted") && Settings["Muted"].ToString() == "True")
                        html += " muted";
                    if (Settings.Contains("ReplaceWithImage") && Settings["ReplaceWithImage"].ToString()=="False" && Settings.Contains("Image"))
                        html += @" poster=""" + PortalSettings.HomeDirectory + Settings["Image"].ToString() + @"""";
                    if (Settings.Contains("Responsive") && Settings["Responsive"].ToString() == "True")
                        html += @" style=""max-width:100%;height:auto;""";
                    html += @""">";
                    html += @"<source src=""" + PortalSettings.HomeDirectory + Settings["MP4Video"] + @""" type=""video/mp4"" />";
                    html += "</video>";

                    if (Settings.Contains("ReplaceWithImage") && Settings["ReplaceWithImage"].ToString() == "True")
                        html += @"<img src=""" + PortalSettings.HomeDirectory + Settings["Image"].ToString() + @""" class=""visible-xs"" style=""max-width:100%;height:auto;display:block;margin:0 auto;"" />";
                    litVideo.Text = html;
                }
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        public ModuleActionCollection ModuleActions
        {
            get
            {
                var actions = new ModuleActionCollection
                    {
                        {
                            GetNextActionID(), Localization.GetString("EditModule", LocalResourceFile), "", "", "",
                            EditUrl(), false, SecurityAccessLevel.Edit, true, false
                        }
                    };
                return actions;
            }
        }
    }
}