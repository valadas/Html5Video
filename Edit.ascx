<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="Eraware.Modules.Html5Video.Edit" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="URL" Src="~/controls/URLControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="FilePickerUploader" Src="~/controls/FilePickerUploader.ascx" %>

<div class="html5video-settings">
    <fieldset>
        <div class="dnnFormItem">
            <dnn:Label id="lblMp4Video" runat="server" Suffix=":" ControlName="ctlMp4Video" />
            <div class="dnnLeft"><dnn:FilePickerUploader id="ctlMp4Video" runat="server" ShowLog="False" /></div>
        </div>
    </fieldset>
    <fieldset>
        <div class="dnnFormItem">
            <dnn:Label id="lblWebmVideo" runat="server" Suffix=":" ControlName="ctlWebmVideo" />
            <div class="dnnLeft"><dnn:FilePickerUploader id="ctlWebmVideo" runat="server" /></div>
        </div>
    </fieldset>
    <fieldset>
        <div class="dnnFormItem">
            <dnn:Label id="lblImage" runat="server" Suffix=":" ControlName="ctlImage" />
            <div class="dnnLeft"><dnn:FilePickerUploader id="ctlImage" runat="server" /></div>
        </div>
    </fieldset>
    <fieldset>
        <div class="dnnFormItem">
            <dnn:Label id="lblReplaceWithIamge" runat="server" Suffix=":" ControlName="chkReplaceWithImage" />
            <asp:CheckBox ID="chkReplaceWithImage" runat="server" />
        </div>
    </fieldset>
    <fieldset>
        <div class="dnnFormItem">
            <dnn:Label id="lblAutoplay" runat="server" Suffix=":" ControlName="chkAutoplay" />
            <asp:CheckBox ID="chkAutoplay" runat="server" />
        </div>
    </fieldset>
    <fieldset>
        <div class="dnnFormItem">
            <dnn:Label id="lblLoop" runat="server" Suffix=":" ControlName="chkLoop" />
            <asp:CheckBox ID="chkLoop" runat="server" />
        </div>
    </fieldset>
    <fieldset>
        <div class="dnnFormItem">
            <dnn:Label id="lblMuted" runat="server" Suffix=":" ControlName="chkMuted" />
            <asp:CheckBox ID="chkMuted" runat="server" />
        </div>
    </fieldset>
    <fieldset>
        <div class="dnnFormItem">
            <dnn:Label id="lblControls" runat="server" Suffix=":" ControlName="chkControls" />
            <asp:CheckBox ID="chkControls" runat="server" />
        </div>
    </fieldset>
    <fieldset>
        <div class="dnnFormItem">
            <dnn:Label id="lblResponsive" runat="server" Suffix=":" ControlName="chkResponsive" />
            <asp:CheckBox ID="chkResponsive" runat="server" />
        </div>
    </fieldset>
</div>
<ul class="dnnActions dnnClear">
		<li><asp:LinkButton id="cmdUpdate" runat="server" CssClass="dnnPrimaryAction" ResourceKey="cmdUpdate" OnClick="cmdUpdate_Click" /></li>
		<li><asp:Hyperlink id="cancelHyperLink" runat="server" CssClass="dnnSecondaryAction" resourcekey="cmdCancel" /></li>
</ul>