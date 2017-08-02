using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace Map
{
    public sealed class World : Map
    {
        private int _centroX, _centroY,
            _mezzoTileX, _mezzoTileY;

        private int _espansioneDalCentroX, _espansioneDalCentroY;

        public World(
                Texture2D texture,
                int textureRows, int textureColumns,
                int[] mapGrid,
                int mapWidth, int mapHeight,
                int screenWidth, int screenHeight,
                int mapStartX, int mapStartY) 
            : base(texture, textureRows, textureColumns, mapGrid, screenWidth, screenHeight, mapStartX, mapStartY, mapWidth, mapHeight)
        {
            // Calcoliamo quanto è lungo mezzo tile per il movimento e dove si trova il centro dello schermo sull'asse X
            _mezzoTileX = TileWidth / 2;
            _centroX = ScreenWidth / 2 - _mezzoTileX;

            // Calcoliamo quanto è alto mezzo tile per il movimento e dove si trova il centro dello schermo sull'asse Y
            _mezzoTileY = TileHeight / 2;
            _centroY = ScreenHeight / 2 - _mezzoTileY;

            // Per ora li settiamo fissi a 5 poi li calcoleremo meglio
            _espansioneDalCentroX = 5;
            _espansioneDalCentroY = 5;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // Per ora facciamo solamente lo spostamento sull'asse X con TMPX (se negativo andiamo verso alto-sinistra / se positivo andiamo verso basso-destra)
            for (int tmpX = MapStartX - _espansioneDalCentroX; tmpX <= MapStartX + _espansioneDalCentroX; tmpX++)
            {
                // Se siamo fuori della mappa con i valori allora non disegnamo nulla.
                if (tmpX < 0 || tmpX >= MapWidth) { continue; }

                // prendiamo la tile da disegnare puntando quella tramite mappa
                int tileInTexture = MapGrid[MapWidth * MapStartY + tmpX] - 1; //x = 1, y = 0 -> indice 1 (texture 1)
                int textureTileRow = (int)((float)tileInTexture / (float)TextureColumns);
                int textureTileColumn = tileInTexture % TextureColumns;

                // Il rettangolo sorgente è il pezzo di mappa che andiamo a mettere in memoria (pronto per essere disegnato)
                Rectangle sourceRectangle = new Rectangle(
                        TileWidth * textureTileColumn, 
                        TileHeight * textureTileRow, 
                        TileWidth, 
                        TileHeight
                    );

                // Il rettangolo di Destinazione invece è quell'area dello schermo in cui disegneremo il pezzo che abbiamo copiato sopra
                Rectangle destinationRectangle = new Rectangle(
                        _centroX + (_mezzoTileX * (tmpX - MapStartX)), // disegnamo partendo dal centro e muovendoci di mezzotile a destra e sinistra in base a tmpX
                        _centroY + (_mezzoTileY * (tmpX - MapStartX)), // Siccome MapStart è il valore del centro nella mappa, devo equilibrare tmp sottraendoci MapStartX così da far si che vada da - _espansioneDalCentroX a + _espansioneDalCentroX
                        TileWidth,
                        TileHeight
                    );

                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            }
        }
   }
}