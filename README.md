# Html5Video

## Allows inserting HTML5 Videos in DotNetNuke

Simply place the module on any page, select or upload your video and it will be placed as an html5 video element.

Options include the following:
* Optionnally provide an image
   * The image can be used as a benner before the video is completely loaded
   * or as a replacement for the video on mobile devices
* Simple checkboxes to select your options:
   * Autoplay (starts the video when it is loaded)
   * Loop (retarts the video idefinitely)
   * Muted (mutes the sound by default)
   * Controls (show media controls)
   * Responsive (adjusts the video so it never is larger than its container)

Known issues:
The following issues have not been implemented due to lack of time, they may be one day implemented if there is enough interest or you can also submit pull requests.
* Currently only supports mp4 since it works on pretty much any recent browser
* Replacing the video with an image on mobile devices currently only works on Bootstrap enabled skins.
