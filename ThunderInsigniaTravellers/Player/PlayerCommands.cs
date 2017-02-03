using System.Collections.Generic;
using ThunderInsigniaTravellers.Characters;
using ThunderInsigniaTravellers.Map;

namespace ThunderInsigniaTravellers.Player
{
    public class PlayerCommands
    {
        private readonly HighlightedMap _map;

        private Tile _selectedTile;
        private Character _selectedCharacter;

        public PlayerCommands(HighlightedMap map)
        {
            _map = map;
        }

        public void Select(Tile location)
        {
            if (CharacterIsSelected)
                MoveSelectedCharacterTo(location);
            SelectCharacterAt(location);
        }

        private void SelectCharacterAt(Tile location)
        {
            _selectedCharacter = _map.GetMap().GetOptionalCharacter(location);
            _selectedTile = location;
            if (CharacterIsSelected)
                _map.SetHighlights(new List<Tile>
                {
                    location.Plus(-1, 0),
                    location.Plus(1, 0),
                    location.Plus(0, -1),
                    location.Plus(0, 1),
                });
        }

        private void MoveSelectedCharacterTo(Tile destination)
        {
            _map.GetMap().Move(_selectedCharacter, _selectedTile, destination);
            ClearSelection();
        }

        private void ClearSelection()
        {
            _selectedTile = null;
            _selectedCharacter = null;
        }

        public bool CharacterIsSelected => _selectedCharacter != null && _selectedTile != null;
    }
}

