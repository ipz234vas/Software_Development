using Memento;

var document = new TextDocument();
var editor = new TextEditor(document);

// Add the first version of the text
document.Append("First version!");
document.Display();
editor.Save();

// Add more text and save again
document.Append(" Additional text...");
document.Display();
editor.Save();

// Add more text without saving
document.Append(" Oops, mistake.");
document.Display();

// Undo the last unsaved change (with "mistake")
editor.Undo();
document.Display();

// Undo again to return to the first version
editor.Undo();
document.Display();

// Try to undo when there are no more saved states
editor.Undo();