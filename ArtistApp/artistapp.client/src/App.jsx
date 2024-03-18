import { Navigate, Route, Routes } from "react-router";
import ArtistMenuLayout from "./shared/layout.component";
import ArtistPage from "./components/Artists/artist-page";
import "./App.css";
import AlbumPage from "./components/Albums/album-page";
import TrackPage from "./components/Tracks/track-page";
import AddArtistPage from "./components/Artists/AddArtist/add-artist-form";
import EditArtistPage from "./components/Artists/editArtist/edit-artist-form";
import AddAlbumPage from "./components/Albums/AddAlbum/add-album-form";
import EditAlbumPage from "./components/Albums/EditAlbum/edit-album-form";
import AddTrackPage from "./components/Tracks/AddTrack/add-track-form";
import EditTrackPage from "./components/Tracks/EditTrack/edit-track-form";
import ViewArtistAlbums from "./components/Artists/view-artist";

function App() {
  return (
    <ArtistMenuLayout>
      <Routes>
        <Route path="/">
          <Route index element={<ArtistPage />} />
          <Route path="add-artist" element={<AddArtistPage />} />
          <Route path="edit-artist/:id" element={<EditArtistPage />} />
          <Route path="view-artist/:id" element={<ViewArtistAlbums />} />
        </Route>
        <Route path="album">
          <Route index element={<AlbumPage />} />
          <Route path="add-album" element={<AddAlbumPage />} />
          <Route path="edit-album/:id" element={<EditAlbumPage />} />
        </Route>
        <Route path="track">
          <Route index element={<TrackPage />} />
          <Route index element={<AlbumPage />} />
          <Route path="add-track" element={<AddTrackPage />} />
          <Route path="edit-track/:id" element={<EditTrackPage />} />
        </Route>
        <Route path="*" element={<Navigate to="/" replace={true} />} />
      </Routes>
    </ArtistMenuLayout>
  );
}

export default App;
