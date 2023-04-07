
using System.Net.Http.Json;



namespace KULIV.MudEmojiPicker.Data
{
    public class EmojiService
    {

        public List<EmojiGroup> EmojiLists = new List<EmojiGroup>();
        private Dictionary<string, string> _twitterEmojis = new Dictionary<string, string>();
        
        public string emptyEmoji = @"<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 36 36""></svg>";
        

        public EmojiService()
        {
            
            _twitterEmojis = typeof(Twemoji).GetFields()
                .ToDictionary(m =>
                {
                    var res = m.Name
                        .Replace("E", "").Replace("_", " ")
                        .ToUpper();
                    
                    return res;
                }, info => info.GetValue(info).ToString());
            
            
            
        }
        
        
        /// <summary>
        ///     Get the Hex values from an emoji
        /// </summary>
        /// <returns> List of Hex Values </returns>
        public static IEnumerable<string> EmojiToHex(string emoji)
        {
            var enumerator = emoji.EnumerateRunes();
            while (enumerator.MoveNext())
                yield return Char.ConvertToUtf32(enumerator.Current.ToString(), 0)
                    .ToString("X");
        }
    
        /// <summary>
        ///     Get the Hex values from an emoji with ouf "FE0F"
        /// </summary>
        /// <returns> List of Hex Values </returns>
        public string EmojiToKey(string emoji)
        {
            var test = EmojiToHex(emoji)
                .Where(s => !s.Equals("FE0F"));
            return string.Join(" ", test);
        }
        
        /// <summary>
        ///     Get a SVG value from the given emoji, so it can be use in an MudIcone
        /// </summary>
        /// <returns> SVG as a string </returns>
        public string GetSvgValue(string emoji)
        {
            try
            {
                string key = EmojiToKey(emoji);
                
                if (_twitterEmojis.ContainsKey(key))
                {
                    return _twitterEmojis[key];
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return emptyEmoji;
        }
        
        
        
        
        
    }
}