function movieReplaceer(strMov) {
var res = strMov.replace("watch?v=", "embed/");
var res1 = res.replace("http:", "");
res1 = "<iframe width='200' height='120'  src='" + res1 + "'></iframe>";
return res1;
}

