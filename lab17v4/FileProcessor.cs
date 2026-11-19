using System;
using System.IO;

namespace lab17v4
{
    public class FileProcessor
    {
        private int _readAttempts = 0;

        public byte[] ReadImage(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Шлях до файлу зображення не може бути порожнім.", nameof(path));
            }

            _readAttempts++;

            if (_readAttempts <= 3)
            {
                throw new FileNotFoundException($"Файл зображення за шляхом '{path}' тимчасово недоступний (спроба {_readAttempts}/3).", path);
            }

            return new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };
        }
    }
}
