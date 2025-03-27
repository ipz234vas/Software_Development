using Adapter;

Logger logger = new Logger();
logger.Log("Everything is good!");
logger.Warn("Just warning");
logger.Error("Something really bad :(");

IFileWriter fileWriter = new FileWriter("logs.txt"); //logs.txt will appear in bin/Debug/net8.0
IFileLogger fileLogger = new FileLogger(fileWriter, logger);
fileLogger.Log("Log inside a file!");
fileLogger.Warn("Dangerous!");
fileLogger.Error("Error...");