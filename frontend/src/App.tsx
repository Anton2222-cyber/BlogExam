import MainPage from "./components/mainPage.tsx";
import {BrowserRouter, Route, Routes} from "react-router-dom";

function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<MainPage/>}/>
                <Route path="/tag/:tagUrlSlug" element={<MainPage/>}/>
            </Routes>
        </BrowserRouter>
    )
}

export default App
