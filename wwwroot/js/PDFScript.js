function generatePDF()
{
    const element = document.getElementById("table");
    html2pdf().from(element).save();
}