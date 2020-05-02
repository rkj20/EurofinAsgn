namespace ClubHouseUtil.Model.Logging.Handlers
{
    using ClubHouseUtil.Model.Logging.Formatters;
    using System;
    using System.IO;

    /// <summary>
    /// Implementation of File logger
    /// </summary>
    /// <seealso cref="ClubHouseUtil.Model.Logging.Handlers.ILogWriter" />
    internal class FileLogger : ILogWriter
    {
        /// <summary>
        /// object to synchronize
        /// </summary>
        private readonly object _syncObject = new object();

        /// <summary>
        /// The log file name
        /// </summary>
        private readonly string _fileName;

        /// <summary>
        /// The log directory
        /// </summary>
        private readonly string _directory;

        /// <summary>
        /// The log message formatter
        /// </summary>
        private readonly IFormatter _formatter;

        /// <summary>
        /// The delete files older than specified dates
        /// </summary>
        private readonly int _deleteFilesOlderThan = 7;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileLogger"/> class.
        /// </summary>
        public FileLogger() : this(new DefaultFormatter()) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileLogger"/> class.
        /// </summary>
        /// <param name="loggerFormatter">The logger formatter.</param>
        public FileLogger(IFormatter loggerFormatter) : this(loggerFormatter, CreateFileName()) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileLogger"/> class.
        /// </summary>
        /// <param name="loggerFormatter">The logger formatter.</param>
        /// <param name="fileName">Name of the file.</param>
        public FileLogger(IFormatter loggerFormatter, string fileName) : this(loggerFormatter, fileName, AppDomain.CurrentDomain.BaseDirectory) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileLogger"/> class.
        /// </summary>
        /// <param name="loggerFormatter">The logger formatter.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="directory">The directory.</param>
        public FileLogger(IFormatter loggerFormatter, string fileName, string directory)
        {
            _formatter = loggerFormatter;
            _fileName = fileName;
            _directory = Path.Combine(directory,"Logs");
            if (!Directory.Exists(_directory))
                Directory.CreateDirectory(_directory);
            CleanUp();
        }

        /// <summary>
        /// Writes the specified log message.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        public void Write(LogMessage logMessage)
        {
            if (!string.IsNullOrEmpty(_directory))
            {
                var directoryInfo = new DirectoryInfo(Path.Combine(_directory));
                if (!directoryInfo.Exists)
                    directoryInfo.Create();
            }

            lock (_syncObject)
            {
                using (var writer = new StreamWriter(File.Open(Path.Combine(_directory, _fileName), FileMode.Append)))
                    writer.WriteLine(_formatter.Format(logMessage));
            }
        }

        /// <summary>
        /// Cleans up old log files
        /// </summary>
        private void CleanUp()
        {
            foreach (string file in Directory.GetFiles(_directory))
            {
                FileInfo fi = new FileInfo(file);
                if (fi.LastAccessTime < DateTime.Now.AddDays(-_deleteFilesOlderThan))
                    try
                    {
                        fi.Delete();
                    }
                    catch (IOException)
                    {
                        // Just Ignore if we can't delete a file
                    }
            }
        }

        /// <summary>
        /// Creates the name of the file.
        /// </summary>
        /// <returns></returns>
        private static string CreateFileName()
        {
            return string.Format("Log_{0:ddMMyyyy_HHmmss}.log", DateTime.Now);
        }
    }
}
