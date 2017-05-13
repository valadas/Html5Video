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
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Web.UI.WebControls;
using DotNetNuke.Common;
using DotNetNuke.Entities.Modules;

namespace Eraware.Modules.Html5Video
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The EditHtml5Video class is used to manage content
    /// 
    /// Typically your edit control would be used to create new content, or edit existing content within your module.
    /// The ControlKey for this control is "Edit", and is defined in the manifest (.dnn) file.
    /// 
    /// Because the control inherits from Html5VideoModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class Edit : Html5VideoModuleBase
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            cancelHyperLink.NavigateUrl = Globals.NavigateURL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    // Mp4 url
                    if (Settings.Contains("MP4Video"))
                        ctlMp4Video.FilePath = Settings["MP4Video"].ToString();
                    // WebM url
                    if (Settings.Contains("WebmVideo"))
                        ctlWebmVideo.FilePath = Settings["WebmVideo"].ToString();
                    // Image
                    if (Settings.Contains("Image"))
                        ctlImage.FilePath = Settings["Image"].ToString();
                    // Replace with image
                    if (Settings.Contains("ReplaceWithImage"))
                    {
                        bool value = false;
                        bool.TryParse(Settings["ReplaceWithImage"].ToString(), out value);
                        chkReplaceWithImage.Checked = value;
                    }
                    // Autoplay
                    if (Settings.Contains("Autoplay"))
                    {
                        bool value = false;
                        bool.TryParse(Settings["Autoplay"].ToString(), out value);
                        chkAutoplay.Checked = value;
                    }
                    // Loop
                    if (Settings.Contains("Loop"))
                    {
                        bool value = false;
                        bool.TryParse(Settings["Loop"].ToString(), out value);
                        chkLoop.Checked = value;
                    }
                    // Muted
                    if (Settings.Contains("Muted"))
                    {
                        bool value = false;
                        bool.TryParse(Settings["Muted"].ToString(), out value);
                        chkMuted.Checked = value;
                    }
                    // Controls
                    if (Settings.Contains("Controls"))
                    {
                        bool value = false;
                        bool.TryParse(Settings["Controls"].ToString(), out value);
                        chkControls.Checked = value;
                    }
                    // Responsive
                    if (Settings.Contains("Responsive"))
                    {
                        bool value = false;
                        bool.TryParse(Settings["Responsive"].ToString(), out value);
                        chkResponsive.Checked = value;
                    }
                }
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ModuleController mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "MP4Video", ctlMp4Video.FilePath);
                mc.UpdateModuleSetting(ModuleId, "WebmVideo", ctlWebmVideo.FilePath);
                mc.UpdateModuleSetting(ModuleId, "Image", ctlImage.FilePath);
                mc.UpdateModuleSetting(ModuleId, "ReplaceWithImage", chkReplaceWithImage.Checked.ToString());
                mc.UpdateModuleSetting(ModuleId, "Autoplay", chkAutoplay.Checked.ToString());
                mc.UpdateModuleSetting(ModuleId, "Loop", chkLoop.Checked.ToString());
                mc.UpdateModuleSetting(ModuleId, "Muted", chkMuted.Checked.ToString());
                mc.UpdateModuleSetting(ModuleId, "Controls", chkControls.Checked.ToString());
                mc.UpdateModuleSetting(ModuleId, "Responsive", chkResponsive.Checked.ToString());
                Response.Redirect(Globals.NavigateURL());
            }
            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
            
        }
    }
}