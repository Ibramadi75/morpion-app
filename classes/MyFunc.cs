namespace MyApp{
    public static class MyFunc{
            public static string CslRead(){
            var lecture = string.Empty ; 
            lecture = Console.ReadLine() ;

            if ( !String.IsNullOrEmpty(lecture) ) {
                return lecture;
            }else{
                return "erreur";
            }
        }
    }
}