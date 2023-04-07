# kuliv.extensions
This is a prewview of component made for Kuliv.dk


# MudEmojiPicker
It is build on https://mudblazor.com
and on the svg from https://twemoji.twitter.com

![image](https://user-images.githubusercontent.com/12255960/230642431-34dd3958-1c64-402a-8d00-22ca52033765.png)

Uses case remember to add:
`builder.Services.AddSingleton<EmojiService>();`
and in the public folder the emojis.

The service, can finde svg from unidecode charter
`EmojiService.GetSvgValue("🤣")`


And we have two different ways to get the emojis
`<MudIcon Icon="@EmojiService.GetSvgValue("🤣")"/>`
or get them directly `class Twemoji`.

If you use the Twemoji.E1f0cf be aware some of the "Null" space there is in emoji is delete.
` <MudIcon Icon="@Twemoji.E1f0cf"/>  `

If you want to use the Emoji Picker, where ´Value is a string (emoji)´ 
`<MudEmojiPicker @bind-Value="context.Emoji"/>`

