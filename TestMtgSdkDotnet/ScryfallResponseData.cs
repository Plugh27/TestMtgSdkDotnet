using System.Collections.Generic;
using Newtonsoft.Json;

// JSONの要素に対応させるので、命名規則のチェックを切る
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace TestMtgSdkDotnet
{
    public class ScryfallCardFace
    {
        [JsonProperty("object")]
        public string objectType { get; set; }
        public string name { get; set; }
        public string mana_cost { get; set; }
        public string type_line { get; set; }
        public string oracle_text { get; set; }
        public List<string> colors { get; set; }
        public string artist { get; set; }
        public string illustration_id { get; set; }
        public ScryfallImageUris image_uris { get; set; }
    }

    public class ScryfallLegalities
    {
        public string standard { get; set; }
        public string future { get; set; }
        public string frontier { get; set; }
        public string modern { get; set; }
        public string legacy { get; set; }
        public string pauper { get; set; }
        public string vintage { get; set; }
        public string penny { get; set; }
        public string commander { get; set; }
        [JsonProperty("1v1")]
        public string OneOnOne { get; set; }
        public string duel { get; set; }
        public string brawl { get; set; }
    }

    public class ScryfallImageUris
    {
        public string small { get; set; }
        public string normal { get; set; }
        public string large { get; set; }
        public string png { get; set; }
        public string art_crop { get; set; }
        public string border_crop { get; set; }
    }

    public class ScryfallCardInfo
    {
        [JsonProperty("object")]
        public string objectType { get; set; }

        public string id { get; set; }
        public string oracle_id { get; set; }
        public List<int> multiverse_ids { get; set; }
        public int mtgo_id { get; set; }
        public int arena_id { get; set; }
        public int tcgplayer_id { get; set; }

        public string name { get; set; }
        public string printed_name { get; set; }
        public string lang { get; set; }
        public string released_at { get; set; }
        public string uri { get; set; }
        public string scryfall_uri { get; set; }
        public string layout { get; set; }
        public bool highres_image { get; set; }
        public ScryfallImageUris image_uris { get; set; }

        public string mana_cost { get; set; }
        public string cmc { get; set; }
        public string type_line { get; set; }
        public string printed_type_line { get; set; }
        public string oracle_text { get; set; }
        public string printed_text { get; set; }
        public string power { get; set; }
        public string toughness { get; set; }
        public List<string> colors { get; set; }
        public List<string> color_identity { get; set; }

        public List<ScryfallCardFace> card_faces { get; set; }

        public ScryfallLegalities legalities { get; set; }
        public List<string> games { get; set; }
        public bool reserved { get; set; }
        public bool foil { get; set; }
        public bool nonfoil { get; set; }
        public bool oversized { get; set; }
        public bool promo { get; set; }
        public bool reprint { get; set; }

        [JsonProperty("set")]
        public string setCode { get; set; }
        [JsonProperty("set_name")]
        public string setName { get; set; }
        [JsonProperty("set_uri")]
        public string setUri { get; set; }
        public string set_search_uri { get; set; }
        public string scryfall_set_uri { get; set; }
        public string rulings_uri { get; set; }
        public string prints_search_uri { get; set; }

        public string collector_number { get; set; }

        public bool digital { get; set; }
        public string rarity { get; set; }
        public string watermark { get; set; }
        public string flavor_text { get; set; }
        public string illustration_id { get; set; }
        public string artist { get; set; }
        public string border_color { get; set; }
        public string frame { get; set; }
        public string frame_effect { get; set; }
        public bool full_art { get; set; }
        public bool story_spotlight { get; set; }
    }



    public class ScryfallResponseData
    {
        [JsonProperty("object")]
        public string objectType { get; set; }

        public int total_cards { get; set; }

        public bool has_more { get; set; }

        public string next_page { get; set; }

        public List<ScryfallCardInfo> data { get; set; } 
    }
}
